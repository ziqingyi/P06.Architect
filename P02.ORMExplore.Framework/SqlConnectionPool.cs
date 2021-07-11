using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework
{
    public enum SqlConnectionType
    {
        Read,
        Write
    }
    public class SqlConnectionPool
    {
        private static readonly object _lock = new object(); 
        public static string GetConnectionString(SqlConnectionType sqlConnectionType)
        {
            string conn;
            switch (sqlConnectionType)
            {
                case SqlConnectionType.Read:
                    conn = Dispatcher(ConfigurationManager.SqlConnectionStringRead);
                    break;
                case SqlConnectionType.Write:
                    conn = ConfigurationManager.SqlConnectionStringWrite;
                    break;
                default:
                    throw new Exception("wrong sql connection type");
            }
            return conn;
        }

        //randomly pick a connection string from subscribers' database. 
        //need to choose different num for different access , use _seed
        private static volatile int _seed = 0;

        private static string Dispatcher(string[] connectionStrings)
        {
            lock (_lock)
            {
                
                //int num = new Random(_seed++).Next(0, connectionStrings.Length);//average frequency

                int num = _seed++ % connectionStrings.Length;//poll, in turn, need lock

                //reset
                if (_seed == 2147483647)
                {
                    _seed = 0;
                }
                return connectionStrings[num];
            }
        }

    }
}
