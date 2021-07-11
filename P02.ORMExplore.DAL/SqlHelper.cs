﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using P02.ORMExplore.Framework;
using P02.ORMExplore.Framework.SqlFilter;
using P02.ORMExplore.Framework.SqlMapping;
using P02.ORMExplore.Model;

namespace P02.ORMExplore.DAL
{
    public class SqlHelper
    {
        private string connStringRead = SqlConnectionPool.GetConnectionString(SqlConnectionType.Read);
        private string connStringWrite = SqlConnectionPool.GetConnectionString(SqlConnectionType.Write);

        //must be implemented from BaseModel, for Key (id)
        public T Find<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = $"{SqlBuilder<T>.GetFindSql()}{id}";
            using (SqlConnection conn = new SqlConnection(connStringRead))
            {
                SqlCommand command = new SqlCommand(sql,conn);
                conn.Open();
                var reader = command.ExecuteReader();
                if (reader.Read())
                {
                    T t1 = Activator.CreateInstance<T>();
                    T t = (T)Activator.CreateInstance(type);
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        string propName = propertyInfo.GetColumnNameFromAttr();
                        var pValue = reader[propName] is DBNull ? null : reader[propName];
                        propertyInfo.SetValue(t,pValue);
                    }
                    return t;
                }
                else
                {
                    return default(T);
                }
            }
        }

        public bool Insert<T>(T t) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = SqlBuilder<T>.GetInsertSql();
            var properties = type.GetPropertiesWithoutKey();//not insert db self increase key

            SqlParameter[] paraArray = properties.Select(p => new SqlParameter($"@{p.GetMappingNameFromAttr()}", p.GetValue(t)?? DBNull.Value    )).ToArray();

            using (SqlConnection conn = new SqlConnection(connStringWrite))
            {
                SqlCommand command = new SqlCommand(sql,conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                int reuslt =command.ExecuteNonQuery();
                return reuslt == 1;
            }
        }




    }
}