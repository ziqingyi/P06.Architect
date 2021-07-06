using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace P02.ORMExplore.Framework
{
    public class ConfigurationManager
    {
        private static string _sqlConnectionString;

        public static string SqlConnectionString
        {
            get
            {
                return _sqlConnectionString;
            }
        }


        static ConfigurationManager()
        {
            string directory = Directory.GetCurrentDirectory();
            var builder = new ConfigurationBuilder()
                .SetBasePath(directory)
                .AddJsonFile("appsettings.json");

            IConfigurationRoot configurationRoot = builder.Build();
            _sqlConnectionString = configurationRoot["connectionString"];
        }






    }
}
