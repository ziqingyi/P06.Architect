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

        public BSecondController(ILogger<BSecondController> logger,
            ILoggerFactory loggerFactory
            , ITestServiceA testServiceA)
        {
            _testServiceA = testServiceA;
            this._logger = logger;
            this._loggerFactory = loggerFactory;
        }


        public IActionResult Index()
        {
            _testServiceA.Show();

            this._logger.LogWarning("this is BSecondController Index");

            return View();
        }
    }
}
