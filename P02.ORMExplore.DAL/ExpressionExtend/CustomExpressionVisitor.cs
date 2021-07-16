using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using P02.ORMExplore.Framework.SqlMapping;

namespace P02.ORMExplore.DAL.ExpressionExtend
{
    public class CustomExpressionVisitor :ExpressionVisitor
    {
        private Stack<string> ConditionStack = new Stack<string>();
        private List<SqlParameter> _sqlParameterList = new List<SqlParameter>();
        private object _tempValue;

        public string GetWhere(out List<SqlParameter> sqlParameters)
        {
            string where = string.Concat(this.ConditionStack.ToArray());
            this.ConditionStack.Clear();
            sqlParameters = _sqlParameterList;
            return where;
        }

        public override Expression Visit(Expression node)
        {
            Console.WriteLine($"Visit entry：{node.NodeType} {node.Type} {node.ToString()}");
            return base.Visit(node);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            Console.WriteLine($"VisitBinary：{node.NodeType} {node.Type} {node.ToString()}");
            this.ConditionStack.Push(")");
            base.Visit(node.Right);
            this.ConditionStack.Push(node.NodeType.ToSqlOperator());
            base.Visit(node.Left);
            this.ConditionStack.Push("(");
            return node;
        }

        protected override Expression VisitConstant(ConstantExpression node)
        {
            Console.WriteLine($"VisitConstant：{node.NodeType} {node.Type} {node.ToString()}");
            this._tempValue = node.Value;
            return node;
        }

        protected override Expression VisitMember(MemberExpression node)
        {
            Console.WriteLine($"VisitMember：{node.NodeType} {node.Type} {node.ToString()}");


            if (node.Expression is ConstantExpression)
            {
                var value1 = this.InvokeValue(node);
                var value2 = this.ReflectionValue(node);
                this._tempValue = value1;
            }
            else
            {
                if (this._tempValue != null)
                {
                    string name = node.Member.GetMappingNameFromAttr();
                    string paraName = $"@{name}{this._sqlParameterList.Count}";
                    string sOperator = this.ConditionStack.Pop();
                    this.ConditionStack.Push(paraName);
                    this.ConditionStack.Push(sOperator);
                    this.ConditionStack.Push(name);

                    var tempValue = this._tempValue;
                    this._sqlParameterList.Add(new SqlParameter(paraName,tempValue));
                    this._tempValue = null;
                }
            }

            return node;
        }


        private object InvokeValue(MemberExpression member)
        {
            var objExp = Expression.Convert(member, typeof(object));//for struct
            return Expression.Lambda<Func<object>>(objExp).Compile().Invoke();
        }

        private object ReflectionValue(MemberExpression member)
        {
            var obj = (member.Expression as ConstantExpression).Value;
            return (member.Member as FieldInfo).GetValue(obj);
        }


        protected override Expression VisitMethodCall(MethodCallExpression m)
        {
            if (m == null) throw new ArgumentNullException("MethodCallExpression");

            this.Visit(m.Arguments[0]);
            string format;
            switch (m.Method.Name)
            {
                case "StartsWith":
                    format = "({0} LIKE {1}+'%')";
                    break;

                case "Contains":
                    format = "({0} LIKE '%'+{1}+'%')";
                    break;

                case "EndsWith":
                    format = "({0} LIKE '%'+{1})";
                    break;

                default:
                    throw new NotSupportedException(m.NodeType + " is not supported!");
            }
            this.ConditionStack.Push(format);
            this.Visit(m.Object);
            string left = this.ConditionStack.Pop();
            format = this.ConditionStack.Pop();
            string right = this.ConditionStack.Pop();
            this.ConditionStack.Push(String.Format(format, left, right));

            return m;
        }











    }
}
