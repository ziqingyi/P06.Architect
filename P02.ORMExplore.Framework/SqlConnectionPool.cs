using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework
{
    public enum SqlConnectionType
    {
        read,
        Write
    }
    public class SqlConnectionPool
    {

        public static string GetConnectionString(SqlConnectionType sqlConnectionType)
        {
            string conn;
            switch (sqlConnectionType)
            {
                case SqlConnectionType.read:
                    conn = ConfigurationManager.SqlConnectionString;
                    break;
                case SqlConnectionType.Write:
                    conn = ConfigurationManager.SqlConnectionString;
                    break;
                default:
                    throw new Exception("wrong sql connection type");
            }
            return conn;
        }







    }
}
