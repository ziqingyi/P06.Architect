using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extras.DynamicProxy;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using P03.DotNetCoreMVC.ProjectUtility.AutofacUtility;

namespace P03.DotNetCoreMVC.ProjectUtility.InterceptService
{

    [Intercept(typeof(CustomAutofacAop))]
    public class A : IA
    {
        private ILoggerFactory _Factory = null;
        private ILogger<A> _logger = null;
        public A(ILoggerFactory loggerFactory,
            ILogger<A> logger)
        {
            this._Factory = loggerFactory;
            this._logger = logger;
        }
        public void Log(string id, string name)
        {
            _logger.LogInformation($"This is {id} _ {name}");
        }

    }
}
