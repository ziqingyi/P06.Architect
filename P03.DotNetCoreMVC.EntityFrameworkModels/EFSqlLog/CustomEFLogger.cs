using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.EFSqlLog
{
    public class CustomEFLogger : ILogger
    {
        private string _categoryName = null;

        public CustomEFLogger(string categoryName)
        {
            this._categoryName = categoryName;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            System.Diagnostics.Debug.WriteLine($"************************************************************");
            System.Diagnostics.Debug.WriteLine($"CustomEFLogger {_categoryName} {logLevel} {eventId} {state} start");

            System.Diagnostics.Debug.WriteLine($"Exception：{exception?.Message}");//if not null, get message
            System.Diagnostics.Debug.WriteLine($"Information：{formatter.Invoke(state, exception)}");

            System.Diagnostics.Debug.WriteLine($"CustomEFLogger {_categoryName} {logLevel} {eventId} {state} end");
            System.Diagnostics.Debug.WriteLine($"************************************************************");
        }
    }
}
