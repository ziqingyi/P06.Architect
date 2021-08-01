using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;

namespace P03.DotNetCoreMVC.Controllers
{
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





            string AllowedHost = this._configuration["AllowedHosts"];
            this._logger.LogWarning("this is CThirdController Index");
            return View();
        }
    }
}
