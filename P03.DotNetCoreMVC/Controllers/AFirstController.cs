using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.Controllers
{
    public class AFirstController : Controller
    {

        private readonly ILogger<AFirstController> _logger;
        private readonly ILoggerFactory _loggerFactory;

        public AFirstController(ILogger<AFirstController> logger, ILoggerFactory loggerFactory)
        {
            _logger = logger;
            this._loggerFactory = loggerFactory;
        }


        public IActionResult Index()
        {


            #region  ILogger in Microsoft.Extensions.Logging
            this._logger.LogWarning("This is AFirstController-Index() ---logger");
            this._loggerFactory.CreateLogger<AFirstController>().LogWarning("This is AFirstController-Index() ---logger factory");

            #endregion




            base.ViewBag.User1 = "userInBag";
            base.ViewData["User2"] = "userInView";
            base.TempData["User3"] = "userInTemp";
            object modelName = "User4";


            #region Test Session
            //GetString is extension method in SessionExtensions class
            string result = base.HttpContext.Session.GetString("User5");

            if (string.IsNullOrWhiteSpace(result))
            {
                base.HttpContext.Session.SetString("User5", "UserInSession");
            }
            #endregion



            return View(modelName);
        }
    }
}
