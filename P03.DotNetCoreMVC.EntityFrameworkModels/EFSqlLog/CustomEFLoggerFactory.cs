using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.EFSqlLog
{
    public class CustomEFLoggerFactory : ILoggerFactory
    {
        public void AddProvider(ILoggerProvider provider)
        {
           
        }

        public ILogger CreateLogger(string categoryName)
        {
            return new CustomEFLogger(categoryName);
        }

        public void Dispose()
        {
            
        }
    }
}
