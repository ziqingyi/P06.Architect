using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace P02.ORMExplore.Framework.SqlMapping
{
    public static class MappingExtend
    {

        //member info can be type of property
        public static string GetMappingName(this MemberInfo memberInfo)
        {
            if (memberInfo.IsDefined(typeof(ORMAbstractMappingAttribute), true))
            {
                var attribute = memberInfo.GetCustomAttribute<ORMAbstractMappingAttribute>();

                return attribute.GetName();
            }
            else
            {
                return memberInfo.Name;
            }
        }

        public static string GetTableName(this Type type)
        {
            if (type.IsDefined(typeof(ORMdbTableAttribute), true))
            {
                ORMdbTableAttribute attribute = type.GetCustomAttribute<ORMdbTableAttribute>();
                return attribute.GetName();
            }
            else
            {
                return type.Name;
            }
        }

        public static string GetColumnName(this PropertyInfo prop)
        {
            if (prop.IsDefined(typeof(ORMdbColumnAttribute), true))
            {
                ORMdbColumnAttribute attribute = prop.GetCustomAttribute<ORMdbColumnAttribute>();
                return attribute.GetName();
            }
            else
            {
                return prop.Name;
            }

        }






    }
}
