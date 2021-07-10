using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace P02.ORMExplore.Framework
{
    public class ConfigurationManager
    {
        private static string _sqlConnectionStringWrite;
        public static string SqlConnectionStringWrite
        {
            get
            {
                return _sqlConnectionStringWrite;
            }
        }

        private static string[] _sqlConnectionStringRead;
        public static string[] SqlConnectionStringRead
        {
            get
            {
                return _sqlConnectionStringRead;
            }
        }

        static ConfigurationManager()
        {
            string directory = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configurationRoot = builder.Build();

            #region connection strings to one write database only.

            _sqlConnectionStringWrite = configurationRoot["connectionStrings:Write"];
            
            #endregion
            

            #region connection strings to multiple read database.

            _sqlConnectionStringRead = configurationRoot.GetSection("connectionStrings")
                .GetSection("Read")
                .GetChildren()
                .Select(s => s.Value)
                .ToArray();

            #endregion



        }






    }
}
