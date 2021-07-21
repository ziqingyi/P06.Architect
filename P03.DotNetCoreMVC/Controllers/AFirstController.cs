using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.Controllers
{
    public class AFirstController : Controller
    {
        public IActionResult Index()
        {
            base.ViewBag.User1 = "userInBag";
            base.ViewData["User2"] = "userInView";
            base.TempData["User3"] = "userInTemp";
            object modelName = "User4";


            #region Test Session

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
