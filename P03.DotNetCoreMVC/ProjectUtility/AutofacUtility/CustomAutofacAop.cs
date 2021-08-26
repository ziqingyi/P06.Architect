using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.ProjectUtility.AutofacUtility
{
    public class CustomAutofacAop:IInterceptor
    {

        //copy from Framework version. 
        private static ILoggerFactory loggerFactory = new LoggerFactory();
        private static ILogger logger;

        static CustomAutofacAop()
        {
            loggerFactory.AddLog4Net("CfgFiles\\log4net.config");
            logger = new Logger<string>(loggerFactory);
        }


        public void Intercept(IInvocation invocation)
        {

            logger.LogInformation($"Invocation. Method ={invocation.Method}");

            logger.LogInformation($"Invocation Arguments={string.Join(",", invocation.Arguments)}");

            invocation.Proceed();

            logger.LogInformation($" Method {invocation.Method} is finished.");
        }

 
    }
}
