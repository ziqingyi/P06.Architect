using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.TestProject
{
    public static class OrderByExtension
    {
        public static IQueryable<T> OrderBy<T>(this IQueryable<T> query, string orderStr)
        {
            //return DynamicQueryable.OrderBy(query, orderStr);
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }
            if (orderStr == null)
            {
                throw new ArgumentNullException("orderStr");
            }

            string text = "OrderBy";
            string text2 = "OrderByDescending";

            string[] orderArray = orderStr.Split(' ');
            if (orderArray.Length % 2 != 0)
            {
                throw new ArgumentException("string format error");
            }

            Expression expression = query.Expression;

            for (int i = 0; i < orderArray.Length; i+=2)
            {
                //column name
                string columnName = orderArray[i];

                //key word
                string nextOrderStr = orderArray[i + 1].ToLower();

                if (!new[] {"asc","desc"}.Contains(nextOrderStr))
                {
                    throw new ArgumentException(nextOrderStr+ "  keyword error, only asc and desc" );
                }

                string order = nextOrderStr == "asc" ? text : text2;

                //type in collection
                Type collectionType = query.ElementType;


                #region m.columnName, by reflection

                //get property by reflection
                PropertyInfo propInfo = collectionType.GetProperty(columnName);

                //parameter expression, with type from IQueryable
                ParameterExpression parameter = Expression.Parameter(collectionType, "m");

                // m.columnName  
                MemberExpression memberexp = Expression.MakeMemberAccess(parameter,propInfo);

                #endregion


                #region lambda expression, (paramter) => (m.columnName)

                LambdaExpression lambdaExp = Expression.Lambda(memberexp, parameter);

                #endregion



                Expression quoteExp = Expression.Quote(lambdaExp);



                expression = Expression.Call(
                    typeof(Queryable),
                    order,
                    new Type[]
                    {
                        collectionType,propInfo.PropertyType
                    },
                    
                    //other parameters, params Expression[] 
                    expression,
                    quoteExp
                    
                    );



                text = "ThenBy";
                text2 = "ThenByDescending";


            }

            return query.Provider.CreateQuery<T>(expression);


        }


    }
}
