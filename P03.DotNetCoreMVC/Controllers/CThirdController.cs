using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using P03.DotNetCoreMVC.Utility.Filters;

namespace P03.DotNetCoreMVC.Controllers
{
    [CustomControllerFilterAttribute]
    public class CThirdController : Controller
    {
        #region Identity
        private readonly ILogger<CThirdController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITestServiceA _testServiceA;
        private readonly ITestServiceB _testServiceB;
        private readonly ITestServiceC _testServiceC;
        private readonly ITestServiceD _testServiceD;
        private readonly ITestServiceE _testServiceE;
        private readonly IServiceProvider _serviceProvider;

        private readonly IConfiguration _configuration;
        #endregion


        public CThirdController(ILogger<CThirdController> logger,
            ILoggerFactory loggerFactory
            , ITestServiceA testServiceA
            , ITestServiceB testServiceB
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD
            , ITestServiceE testServiceE
            , IServiceProvider serviceProvider
            , IConfiguration configuration)
        {
            _testServiceA = testServiceA;
            _testServiceB = testServiceB;
            _testServiceC = testServiceC;
            _testServiceD = testServiceD;
            _testServiceE = testServiceE;
            _serviceProvider = serviceProvider;
            _configuration = configuration;

            this._logger = logger;
            this._loggerFactory = loggerFactory;
        }


        public IActionResult Index()
        {

            #region test configuration
            string AllowedHost = this._configuration["AllowedHosts"];
            string writeConn = this._configuration["connectionStrings:Write"];
            string[] _readConn = this._configuration.GetSection("connectionStrings")
                .GetSection("Read").GetChildren().Select(s => s.Value).ToArray();

            this._logger.LogWarning("this is CThirdController Index");
            #endregion

            return View();
        }
        //order: 0,1,2   2,1,0
        [CustomActionFilter(Order = 1)]
        [CustomActionFilter(Order = 2)]
        [CustomActionFilter]
        public IActionResult TestActionFilter()
        {
            Console.WriteLine($" this is {nameof(CThirdController)} TestActionFilter()");
            return View();
        }



        #region Test  Exception handling filters

        public IActionResult TestException()
        {
            string AllowedHost = this._configuration["AllowedHost"].ToString();

            return View();
        }

        //attribute is initialized when compile(other when running created by container)
        //so cannot have reference type parameter or use service filter. [CustomExceptionFilterAttribute]
        [ServiceFilter(typeof(CustomExceptionFilterAttribute))]//filter factory, need to config service
        public IActionResult TestExceptionTypeFilter()
        {
            string AllowedHost = this._configuration["AllowedHost"].ToString();

            return View();
        }

        //Service arguments are found in the dependency injection container
        [TypeFilter(typeof(CustomExceptionFilterNewAttribute))] //no service config
        public IActionResult TestExceptionTypeFilterNew()
        {
            string AllowedHost = this._configuration["AllowedHost"].ToString();

            return View();
        }


        [CustomIOCFilterFactoryAttribute]
        public IActionResult TestExceptionIOC()
        {
            string AllowedHost = this._configuration["AllowedHost"].ToString();

            return View();
        }

        #endregion







    }
}
