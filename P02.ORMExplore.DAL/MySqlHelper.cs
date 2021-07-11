using P02.ORMExplore.IDAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using P02.ORMExplore.Framework;
using P02.ORMExplore.Framework.SqlMapping;
using P02.ORMExplore.Model;

namespace P02.ORMExplore.DAL
{
    /// <summary>
    /// limit the type of T,
    /// all T passed must have ID, so defined in BaseModel
    /// </summary>
    public class MySqlHelper :IBaseDAL
    {


        //private static string ConnectionStringCustomers = ConfigurationManager.ConnectionStrings["Customers"].ConnectionString;
        //private static string ConnectionStringCustomers = StaticConstraint.DBconnection;
        //private static string ConnectionStringCustomers = @"server=.;uid=sa;pwd=123;database=RPracticeDB";
        private  string connStringRead = SqlConnectionPool.GetConnectionString(SqlConnectionType.Read);
        private  string connStringWrite = SqlConnectionPool.GetConnectionString(SqlConnectionType.Write);
        public bool Add<T>(T t) where T : BaseModel
        {
            #region method 1
            //Type type = t.GetType();
            //var test = type.GetProperties();
            //var tlinq = type.GetProperties().Select(p => p.Name);
            ////should not have inherted members. 
            //String columnString = string.Join(",",
            //    type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public)
            //        .Select(p => $"[{p.Name}]"));

            //String valueColumn = String.Join(",",
            //    type.GetProperties(BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Public).Select(p => $"'{p.GetValue(t)}'"));

            //String sql =
            //    $"INSERT INTO [{type.Name}]  ({columnString}) values ({valueColumn})";
            //using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            //{
            //    SqlCommand cmd = new SqlCommand(sql,conn);
            //    conn.Open();
            //    return cmd.ExecuteNonQuery()==1;
            //}
            #endregion

            #region method 2
            //String sql = MySqlBuilder<T>.InsertSql;
            //// static construct method be called only once before first use of static element or new instance

            ////use same list from builder. 
            //var parameterList = MySqlBuilder<T>.propList
            //    .Select(p => new SqlParameter($"@{p.GetColumnName()}",p.GetValue(t)?? "")); 
            ////can use DBNull.Value, but some column not null

            //using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            //{
            //    SqlCommand cmd = new SqlCommand(sql, conn);
            //    cmd.Parameters.AddRange(parameterList.ToArray());
            //    conn.Open();
            //    return cmd.ExecuteNonQuery() == 1;
            //}
            #endregion

            #region method 3, update with delegate, using shared logic
            String sql = MySqlBuilder<T>.InsertSql;
            // static construct method be called only once before first use of static element or new instance
            //use same list from builder. 
            var parameterList = MySqlBuilder<T>.propList
                .Select(p => new SqlParameter($"@{p.GetColumnNameFromAttr()}", p.GetValue(t) ?? ""));
            //can use DBNull.Value, but some column not null
            Func<SqlCommand, bool> insertLogic = (command) =>
            {
                command.Parameters.AddRange(parameterList.ToArray());
                return command.ExecuteNonQuery() == 1;
            };
            return this.ExecuteSql(sql, insertLogic);
            #endregion
        }

        public bool Delete<T>(T t) where T : BaseModel
        {
            #region method 1 simple one
            //String Sql = MySqlBuilder<T>.DeleteSql;
            //SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            //p.Value = t.Id;
            //using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            //{
            //    SqlCommand cmd = new SqlCommand(Sql,conn);
            //    cmd.Parameters.Add(p);
            //    conn.Open();
            //    return cmd.ExecuteNonQuery() == 1;
            //}
            #endregion
            #region method 2 use delegate
            String Sql = MySqlBuilder<T>.DeleteSql;
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = t.Id;
            Func<SqlCommand, bool> deleteLogic = (command) =>
            {
                command.Parameters.Add(p);
                return command.ExecuteNonQuery() == 1;
            };
            return ExecuteSql(Sql, deleteLogic);
            #endregion
        }

        public List<T> FindAll<T>() where T : BaseModel
        {
            #region method 1 , normaly way 
            //Type type = typeof(T);
            //List<T> allObj = new List<T>();
            //String Sql = MySqlBuilder<T>.FindAllSql;
            //using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            //{
            //    conn.Open();
            //    using (SqlCommand command = new SqlCommand(Sql, conn))
            //    {
            //        SqlDataReader reader = command.ExecuteReader();
            //        while (reader.Read())
            //        {
            //            object obj = Activator.CreateInstance(type);

            //            obj = MySqlBuilder<T>.CreateObjectFromSqlDataReader<T>(reader);

            //            allObj.Add( (T)obj);
            //        }
            //        reader.Close();
            //    }
            //}
            //return allObj;
            #endregion

            #region method 2, use delegate
            Type type = typeof(T);
            List<T> allObj = new List<T>();
            String Sql = MySqlBuilder<T>.FindAllSql;

            Func<SqlCommand, List<T>> findallLogic = (command) =>
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object obj = Activator.CreateInstance(type);
                    obj = MySqlBuilder<T>.CreateObjectFromSqlDataReader<T>(reader);
                    allObj.Add((T)obj);
                }
                reader.Close();
                return allObj;
            };
            return ExecuteSql(Sql, findallLogic);
            #endregion
        }
        // help to build connection and prepare command, then pass SqlCommand to shared logic
        private T ExecuteSql<T>(string sql, Func<SqlCommand, T> func)
        {
            //conn.begintransaction()
            //try catch rollback
            // command.Parameters.addrange(parameterlist.ToArray())
            using (SqlConnection conn = new SqlConnection(connStringWrite))
            {
                SqlCommand command = new SqlCommand(sql, conn);
                conn.Open();
                return func.Invoke(command);
            }
        }

        public T FindTwithDelegate<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            String Sql = MySqlBuilder<T>.FindSql;
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            Func<SqlCommand, T> delogic = (command) =>
            {
                //note this, when ExecuteSql() is working here, it still can add p.
                command.Parameters.Add(p);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    object obj = Activator.CreateInstance(type);
                    obj = MySqlBuilder<T>.CreateObjectFromSqlDataReader<T>(reader);
                    reader.Close();
                    return (T)obj;
                }
                else
                {
                    return null; //not exist in database 
                }
            };
            return ExecuteSql(Sql, delogic);
        }
        public T FindT<T>(int id) where T : BaseModel
        {
            Type type = typeof(T);
            String Sql = MySqlBuilder<T>.FindSql;
            SqlParameter p = new SqlParameter("@id", SqlDbType.Int);
            p.Value = id;
            using (SqlConnection conn = new SqlConnection(connStringRead))
            {
                conn.Open();
                using (SqlCommand command = new SqlCommand(Sql, conn))
                {
                    command.Parameters.Add(p);
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.Read())
                    {
                        object obj = Activator.CreateInstance(type);
                        obj = MySqlBuilder<T>.CreateObjectFromSqlDataReader<T>(reader);

                        reader.Close();
                        return (T)obj;
                    }
                    else
                    {
                        return null; //not exist in database 
                    }
                }
            }
        }


        public bool Update<T>(T t) where T : BaseModel
        {
            Type type = typeof(T);

            String Sql = MySqlBuilder<T>.ModifySql;
            List<SqlParameter> list = new List<SqlParameter>();
            //then build your sql parameters. need to have id.
            foreach (var prop in MySqlBuilder<T>.propListAllPub)
            {
                //test parameter type
                string pname = "@" + prop.GetColumnNameFromAttr();
                SqlParameter para = new SqlParameter(pname, prop.PropertyType.Name);
                para.Value = prop.GetValue(t);
                list.Add(para);
            }
            // method 1, normal way to execute query
            //using (SqlConnection conn = new SqlConnection(ConnectionStringCustomers))
            //{
            //    conn.Open();
            //    using (SqlCommand command = new SqlCommand(Sql, conn))
            //    {
            //        command.Parameters.AddRange(list.ToArray());
            //        return command.ExecuteNonQuery() == 1;
            //    }
            //}
            // method 2, simply with delegate
            Func<SqlCommand, bool> updateLogic = (command) =>
            {
                command.Parameters.AddRange(list.ToArray());
                return (command.ExecuteNonQuery() == 1);
            };
            return ExecuteSql(Sql, updateLogic);
        }
    }


}
