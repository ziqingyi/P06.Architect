using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace P02.ORMExplore.Framework.SqlFilter
{
    public static class FilterExtend
    {
        //return all property fields except Key filed

        public static IEnumerable<PropertyInfo> GetPropertiesWithoutKey(this Type type)
        {

            return type.GetProperties().Where(p => !p.IsDefined(typeof(ORMModelKeyAttribute), true));

        }

        public static IEnumerable<PropertyInfo> GetPropertiesInJson(this Type type, string json)
        {
            return type.GetPropertiesWithoutKey().Where(p => json.Contains($"'{p.Name}':") || json.Contains($"\"{p.Name}\":"));

        }




    }
}
