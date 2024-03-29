﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using P02.ORMExplore.DAL.ExpressionExtend;
using P02.ORMExplore.Framework;
using P02.ORMExplore.Framework.SqlFilter;
using P02.ORMExplore.Framework.SqlMapping;
using P02.ORMExplore.Framework.Validation;
using P02.ORMExplore.Model;

namespace P02.ORMExplore.DAL
{
    public class SqlHelper
    {
        private string connStringRead = SqlConnectionPool.GetConnectionString(SqlConnectionType.Read);
        private string connStringWrite = SqlConnectionPool.GetConnectionString(SqlConnectionType.Write);

        //must be implemented from BaseModel, for Key (id)
        public T Find<T>(int id) where T : BaseModel,new()
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
                    T t2 = new T();//if T must have new()

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


        public IList<T> FindCondition<T>(Expression<Func<T,bool>> func) where T : BaseModel, new()
        {
            Type type = typeof(T);
            string columnsString = string.Join(",", type.GetProperties().Select(p => $"[{p.GetMappingNameFromAttr()}]"));
            string where = func.ToWhere(out List<SqlParameter> parameters);

            string _findSql = $"Select {columnsString} from [{type.GetMappingNameFromAttr()}] where {where}";

            IList<T> result = new List<T>();

            using (SqlConnection conn = new SqlConnection(connStringRead))
            {
                SqlCommand command = new SqlCommand(_findSql, conn);
                command.Parameters.AddRange(parameters.ToArray());
                conn.Open();
                var reader = command.ExecuteReader();
                
                while(reader.Read())
                {
                    T t1 = Activator.CreateInstance<T>();
                    T t2 = new T();//if T must have new()

                    T t = (T)Activator.CreateInstance(type);
                    foreach (PropertyInfo propertyInfo in type.GetProperties())
                    {
                        string propName = propertyInfo.GetColumnNameFromAttr();
                        var pValue = reader[propName] is DBNull ? null : reader[propName];
                        propertyInfo.SetValue(t, pValue);
                    }
                    result.Add(t); 
                }

                return result;
            }
        }








        public int Insert<T>(T t) where T : BaseModel
        {
            if (t.ValidateAll().Result == false)
            {
                throw new Exception(t.ValidateAll().Message);
            }

            Type type = typeof(T);
            string sql = SqlBuilder<T>.GetInsertSql();
            var properties = type.GetPropertiesWithoutKey();//not insert db self increase key

            SqlParameter[] paraArray = properties.Select(p => new SqlParameter($"@{p.GetMappingNameFromAttr()}", p.GetValue(t)?? DBNull.Value    )).ToArray();

            using (SqlConnection conn = new SqlConnection(connStringWrite))
            {
                SqlCommand command = new SqlCommand(sql,conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                object result = command.ExecuteScalar();

                int resultKey = int.TryParse(result?.ToString(), out int key) ? key : -1;

                return resultKey;
            }
        }
        public int InsertInDuplicateDB<T>(T t) where T : BaseModel
        {
            if (t.ValidateAll().Result == false)
            {
                throw new Exception(t.ValidateAll().Message);
            }

            Type type = typeof(T);
            string sql = SqlBuilder<T>.GetInsertSql();
            var properties = type.GetPropertiesWithoutKey();//not insert db self increase key

            SqlParameter[] paraArray = properties.Select(p => new SqlParameter($"@{p.GetMappingNameFromAttr()}", p.GetValue(t) ?? DBNull.Value)).ToArray();

            using (SqlConnection conn = new SqlConnection(connStringRead))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                object result = command.ExecuteScalar();

                int resultKey = int.TryParse(result?.ToString(), out int key) ? key : -1;

                return resultKey;
            }
        }
        public int Update<T>(T t) where T : BaseModel
        {
            if (t.ValidateAll().Result == false)
            {
                throw  new Exception(t.ValidateAll().Message);
            }

            Type type = typeof(T);
            string sql = SqlBuilder<T>.GetUpdateSql();
            var properties = type.GetProperties();//include db self increase key, update sql has id as parameter.

            SqlParameter[] paraArray = properties.Select(p => new SqlParameter($"@{p.GetMappingNameFromAttr()}", p.GetValue(t) ?? DBNull.Value)).ToArray();

            using (SqlConnection conn = new SqlConnection(connStringWrite))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                return command.ExecuteNonQuery();
            }
        }


        public int Update<T>(string json, T t) where T : BaseModel
        {
            if (t.ValidateAll().Result == false)
            {
                throw new Exception(t.ValidateAll().Message);
            }



            Type type = typeof(T);

     
            string valuesString = string.Join(",", type.GetPropertiesInJson(json).Select(p => $"{p.GetMappingNameFromAttr()} = @{p.GetMappingNameFromAttr()}"));

            string updateSqlForSomeColumns = $"update  [{type.GetMappingNameFromAttr()}] set {valuesString} where Id = @Id ; ";


            string sql = updateSqlForSomeColumns;
            var properties = type.GetPropertiesInJson(json);//include db self increase key, update sql has id as parameter.

            //prepare sql parameter, must add @Id
            SqlParameter[] paraArray = properties.Select(p => new SqlParameter($"@{p.GetMappingNameFromAttr()}", p.GetValue(t) ?? DBNull.Value)).ToArray();
            paraArray=paraArray.Append(new SqlParameter("@Id", t.Id)).ToArray();

            using (SqlConnection conn = new SqlConnection(connStringWrite))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                return command.ExecuteNonQuery();
            }
        }



        public int Delete<T>(T t) where T : BaseModel
        {
            Type type = typeof(T);
            string sql = SqlBuilder<T>.GetDeleteSql();
            var properties = type.GetProperties();//include db self increase key, update sql has id as parameter.

            SqlParameter[] paraArray = properties.Select(p => new SqlParameter($"@{p.GetMappingNameFromAttr()}", p.GetValue(t) ?? DBNull.Value)).ToArray();

            using (SqlConnection conn = new SqlConnection(connStringWrite))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                command.Parameters.AddRange(paraArray);
                conn.Open();
                return command.ExecuteNonQuery();
            }
        }

    }
}
