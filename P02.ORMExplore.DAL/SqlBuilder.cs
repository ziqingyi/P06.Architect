using P02.ORMExplore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using P02.ORMExplore.Framework.SqlFilter;
using P02.ORMExplore.Framework.SqlMapping;

namespace P02.ORMExplore.DAL
{
    public class SqlBuilder<T> where T: BaseModel
    {

        private static string _findSql;
        private static string _insertSql;

        static SqlBuilder()
        {
            Type type = typeof(T);
            {
                string columnsString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingName()}]"));
                _findSql = $"Select {columnsString} from [{type.GetMappingName()}] where Id = ";
            }

            {
                string columnString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $"[{p.GetMappingName()}]"));
                string valuesString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $@"{p.GetMappingName()}"));

                _insertSql = $"Insert into [{type.GetMappingName()}] ({columnString})  values ({valuesString})";
            }

        }

        public static string GetFindSql()
        {
            return _findSql;
        }

        public static string GetInsertSql()
        {
            return _insertSql;
        }



    }
}
