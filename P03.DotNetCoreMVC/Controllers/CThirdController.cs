using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using P03.DotNetCoreMVC.Utility.Filters;
using P03.DotNetCoreMVC.Utility.CustomAOP;
using Microsoft.Extensions.Options;
using P03.DotNetCoreMVC.Models;
using Microsoft.AspNetCore.Http;

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

        #region options

        private IOptions<EmailOption> _optionsDefault;
        private IOptionsMonitor<EmailOption> _optionsMonitor;
        private IOptionsSnapshot<EmailOption> _optionsSnapshot;

        #endregion

        public CThirdController(ILogger<CThirdController> logger,
            ILoggerFactory loggerFactory
            , ITestServiceA testServiceA
            , ITestServiceB testServiceB
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD
            , ITestServiceE testServiceE
            , IServiceProvider serviceProvider
            , IConfiguration configuration

            , IOptions<EmailOption> optionsDefault//singletion, no change
            , IOptionsMonitor<EmailOption> optionsMonitor//file update support, monitor file updates
            , IOptionsSnapshot<EmailOption> optionsSnapshot)//create when have new request, same in same request, 
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

            #region options

            this._optionsDefault = optionsDefault;
            this._optionsMonitor = optionsMonitor; 
            this._optionsSnapshot = optionsSnapshot;

            #endregion
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


            #region autofac and AOP

            //autofac show
            this._testServiceA.Show();

            //aop show
            var serviceA_AOP = (ITestServiceA)this._testServiceA.AOP(typeof(ITestServiceA));
            serviceA_AOP.Show();

            #endregion


            return View();
        }

        public IActionResult IndexSession()
        {

            string user = base.HttpContext.Session.GetString("CurrentUser");

            if(string.IsNullOrEmpty(user))
            {
                base.HttpContext.Session.SetString("CurrentUser", $"TestUser-{this._configuration["port"]}");
                this._logger.LogWarning($"This is CThirdController {this._configuration["port"]} Session");
            }

            base.ViewBag.SessionUser = base.HttpContext.Session.GetString("CurrentUser");

            return View();
        }



        #region  Test Options

        public IActionResult TestOptions()
        {
            base.ViewBag.defaultEmailOption = this._optionsDefault.Value;

            base.ViewBag.defaultEmailOption1 = _optionsMonitor.CurrentValue;//_optionsMonitor.Get(Microsoft.Extensions.Options.Options.DefaultName);
            
            base.ViewBag.fromMemoryEmailOption1 = _optionsMonitor.Get("FromMemory");

            //test updates in config json file
            base.ViewBag.fromConfigurationEmailOption1 = _optionsMonitor.Get("FromConfiguration");
            base.ViewBag.fromConfigurationEmailOptionNew = _optionsMonitor.Get("FromConfigurationNew");


            base.ViewBag.defaultEmailOption2 = _optionsSnapshot.Value;//_optionsSnapshot.Get(Microsoft.Extensions.Options.Options.DefaultName);
            base.ViewBag.fromMemoryEmailOption2 = _optionsSnapshot.Get("FromMemory");
            base.ViewBag.fromConfigurationEmailOption2 = _optionsSnapshot.Get("FromConfiguration");


            return View();
        }

        #endregion



        #region Action filters and order
        //order: 0,1,2   2,1,0
        [CustomActionFilter(Order = 1)]
        [CustomActionFilter(Order = 2)]
        [CustomActionFilter]
        public IActionResult TestActionFilter()
        {
            Console.WriteLine($" this is {nameof(CThirdController)} TestActionFilter()");
            return View();
        }
        #endregion


        #region Resource Filter and cache actionResult in Dictionary and Browser cache. 
        [CustomActionCacheFilter]
        [CustomResourceFilter]
        public IActionResult TestResourceFilter()
        {
            Console.WriteLine($" this is {nameof(CThirdController)} TestResourceFilter()");

            base.ViewBag.Now = DateTime.Now;

            Thread.Sleep(2000);

            return View();
        }

        #endregion




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
