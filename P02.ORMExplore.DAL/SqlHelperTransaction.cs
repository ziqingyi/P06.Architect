using System;
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
    //if IOC, different instance of SqlHelperTransaction will keep different  connections, transactions
    public class SqlHelperTransaction:IDisposable
    {
        private string connStringRead = SqlConnectionPool.GetConnectionString(SqlConnectionType.Read);
        private string connStringWrite = SqlConnectionPool.GetConnectionString(SqlConnectionType.Write);

        private IList<SqlCommand> _sqlCommands = new List<SqlCommand>();

        public void Insert<T>(T t) where T : BaseModel
        {

            if (t.ValidateAll().Result == false)
            {
                throw new Exception(t.ValidateAll().Message);
            }

            Type type = typeof(T);
            string sql = SqlBuilder<T>.GetInsertSql();
            var properties = type.GetPropertiesWithoutKey();//not insert db self increase key

            SqlParameter[] paraArray = properties.Select(p => new SqlParameter($"@{p.GetMappingNameFromAttr()}", p.GetValue(t) ?? DBNull.Value)).ToArray();

            SqlCommand command = new SqlCommand(sql);
            command.Parameters.AddRange(paraArray);
            _sqlCommands.Add(command);
        }


        public void SaveAllChangesInOneTransaction()
        {
            if (_sqlCommands.Count > 0)
            {
                using (SqlConnection conn = new SqlConnection(connStringWrite))
                {
                    conn.Open();
                    using (SqlTransaction trans = conn.BeginTransaction())//use transactions in commit. 
                    {
                        try
                        {
                            foreach (SqlCommand command in _sqlCommands)
                            {
                                command.Connection = conn;
                                command.Transaction = trans;
                                command.ExecuteNonQuery();
                            }
                            trans.Commit();
                        }
                        catch (Exception e)
                        {
                            trans.Rollback();
                            throw;
                        }
                        finally
                        {
                            this._sqlCommands?.Clear();
                        }
                    }
                }
            }

        }

        public void Dispose()
        {
            this._sqlCommands?.Clear();
        }

        public T Find<T>(int id) where T : BaseModel, new()
        {
            Type type = typeof(T);
            string sql = $"{SqlBuilder<T>.GetFindSql()}{id}";
            using (SqlConnection conn = new SqlConnection(connStringRead))
            {
                SqlCommand command = new SqlCommand(sql, conn);
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
                        propertyInfo.SetValue(t, pValue);
                    }
                    return t;
                }
                else
                {
                    return default(T);
                }
            }
        }


    }
}
