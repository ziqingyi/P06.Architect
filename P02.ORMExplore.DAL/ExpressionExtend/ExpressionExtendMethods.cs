using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using System.Text;

namespace P02.ORMExplore.DAL.ExpressionExtend
{
    public static class ExpressionExtendMethods
    {
        public static string ToWhere<T>(this Expression<Func<T, bool>> expression, out List<SqlParameter> sqlParameters)
        {
            CustomExpressionVisitor visitor = new CustomExpressionVisitor();
            visitor.Visit(expression);
            string where = visitor.GetWhere(out sqlParameters);
            return where;
        }




    }
}
