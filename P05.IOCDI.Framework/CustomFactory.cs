using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace P05.IOCDI.Framework
{
    public class CustomFactory
    {
        private static string currentDir = Directory.GetCurrentDirectory()+"\\";
        public static T Create<T>(params object[] arguments)
        {
            string className = typeof(T).Name;
            string classDll = ConfigurationManager.GetNode(className);

            Assembly assembly = Assembly.LoadFile(currentDir + classDll.Split(',')[1]);
            Type type = assembly.GetType(classDll.Split(',')[0])!;

            object oInstance = Activator.CreateInstance(type,arguments)!;

            return (T)oInstance;
        }










        #region read from appsettings.json

        private class ConfigurationManager
        {
            private static IConfigurationRoot _iConfiguration;

            static ConfigurationManager()
            {
                var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");
                _iConfiguration = builder.Build();

            }

            public static string GetNode(string nodeName)
            {
                string n =  _iConfiguration[nodeName];
                return n;
            }

        }

        #endregion


    }
}
