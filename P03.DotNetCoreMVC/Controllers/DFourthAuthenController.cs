using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P03.DotNetCoreMVC.Utility;
using P03.DotNetCoreMVC.Utility.Extensions;

namespace P03.DotNetCoreMVC.Controllers
{
    public class DFourthAuthenController : Controller
    {
        
        /// <summary>
        /// Authorization:
        ///        1 UseAuthorization in startup class, in Configure and Service Methods
        ///        2 Use Claim Principle in HttpContext context instance
        /// </summary>
        /// <returns></returns>


        [Authorize]
        public IActionResult Index()
        {
            return View();
        }

        #region Login and log out

        //by pass authorize if authorize is configured globally or whole controller. 
        [HttpGet]
        public ViewResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string name, string password, string captcha)
        {
            string formName = base.HttpContext.Request.Form["Name"];

            LoginResult result = base.HttpContext.LoginInCoreAuthentication(name, password, captcha,
                LoginHelper.GetUser, LoginHelper.CheckPass, LoginHelper.CheckStatusActive);

            if (result == LoginResult.Success)
            {
                return base.Redirect("/DFourthAuthen/Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        { 
            UserManagerCore.UserLogout(this.HttpContext);
            return this.Redirect("~/DFourthAuthen/Login");
        }
        #endregion



        #region Captcha Verification
        //[CustomAllowAnonymous]
        public ActionResult CreateCaptchaFile()
        {
            return LoginHelper.CreateCaptchaFile(this);
        }
        //[CustomAllowAnonymous]
        public void CreateCaptchaResponse(HttpContext httpContext)
        {
            LoginHelper.CreateCaptchaResponse(this);
        }
        #endregion





    }
}