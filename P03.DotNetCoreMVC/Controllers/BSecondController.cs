using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;

namespace P03.DotNetCoreMVC.Controllers
{
    public class BSecondController : Controller
    {
        private readonly ILogger<BSecondController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ITestServiceA _testServiceA;
        private readonly ITestServiceB _testServiceB;
        private readonly ITestServiceC _testServiceC;
        private readonly ITestServiceD _testServiceD;
        private readonly ITestServiceE _testServiceE;

        public BSecondController(ILogger<BSecondController> logger,
            ILoggerFactory loggerFactory
            , ITestServiceA testServiceA
            , ITestServiceB testServiceB
            , ITestServiceC testServiceC
            , ITestServiceD testServiceD
            , ITestServiceE testServiceE)
        {
            _testServiceA = testServiceA;
            _testServiceB = testServiceB;
            _testServiceC = testServiceC;
            _testServiceD = testServiceD;
            _testServiceE = testServiceE;

            this._logger = logger;
            this._loggerFactory = loggerFactory;
        }


        public IActionResult Index()
        {
            _testServiceA.Show();
            _testServiceB.Show();
            _testServiceC.Show();
            _testServiceD.Show();
            _testServiceE.Show();

            this._logger.LogWarning("this is BSecondController Index");

            return View();
        }
    }
}
