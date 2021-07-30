using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.Controllers
{
    public class BSecondController : Controller
    {
        private readonly ILogger<BSecondController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public BSecondController(ILogger<BSecondController> logger,
            ILoggerFactory loggerFactory)
        {
            this._logger = logger;
            this._loggerFactory = loggerFactory;
        }


        public IActionResult Index()
        {
            this._logger.LogWarning("this is BSecondController Index");

            return View();
        }
    }
}
