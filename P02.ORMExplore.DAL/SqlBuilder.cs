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
        private static string _updateSql;
        private static string _deleteSql;

        static SqlBuilder()
        {
            Type type = typeof(T);
            {
                string columnsString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingNameFromAttr()}]"));
                _findSql = $"Select {columnsString} from [{type.GetMappingNameFromAttr()}] where Id = ";
            }

            {
                string columnString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $"[{p.GetMappingNameFromAttr()}]"));
                string valuesString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $"@{p.GetMappingNameFromAttr()}"));

                _insertSql = $"Insert into [{type.GetMappingNameFromAttr()}] ({columnString})  values ({valuesString}); select @@Identity";
            }
            {
                //databaseName = @typeFieldName
                string valuesString = string.Join(",", type.GetPropertiesWithoutKey().Select(p => $"{p.GetMappingNameFromAttr()} = @{p.GetMappingNameFromAttr()}"));

                _updateSql = $"update  [{type.GetMappingNameFromAttr()}] set {valuesString} where Id = @id ; ";
            }
            {
                _deleteSql = $"delete from [{type.GetMappingNameFromAttr()}] where Id = @id ; ";
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

        public static string GetUpdateSql()
        {
            return _updateSql;
        }
        public static string GetDeleteSql()
        {
            return _deleteSql;
        }

    }
}
