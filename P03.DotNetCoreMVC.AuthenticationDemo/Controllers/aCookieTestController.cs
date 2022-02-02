using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P03.DotNetCoreMVC.Utility.Filters.AuthFilters;
using P03.DotNetCoreMVC.Utility.Models;
using System;
using System.Diagnostics;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Controllers
{
    [CustomAuthorizationFilter]
    public class aCookieTestController : Controller
    {
        private static int i = 0;
        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public IActionResult Login(string name, string password)
        {

            string AnonymousName = "anonymous" + i++;
            //.net core MVC Cookie,  keep 30 minutes
            base.HttpContext.Response.Cookies.Append("CurrentUser", AnonymousName,
                new CookieOptions()
                {
                    Expires = DateTime.Now.AddMinutes(30)
                });


            return new JsonResult(new
            {
                Result = true,
                Message = "Login Successfully!"
            });
        }




        public IActionResult Error()
        {
            ErrorViewModel evm = new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };

            return View(evm);
        }




    }
}
