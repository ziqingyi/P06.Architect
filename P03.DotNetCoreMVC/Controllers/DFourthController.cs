using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using P03.DotNetCoreMVC.ProjectUtility;
using P03.DotNetCoreMVC.Utility.Extensions;
using P03.DotNetCoreMVC.Utility.Filters;

namespace P03.DotNetCoreMVC.Controllers
{
   
    public class DFourthController : Controller
    {
 


        [TypeFilter(typeof(CustomActionCheckFilterAttribute))]
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
        public ActionResult Login(string name, string password,string captcha)
        {
            string formName = base.HttpContext.Request.Form["Name"];

            LoginResult result = base.HttpContext.Login(name, password, captcha, 
                LoginHelper.GetUser, LoginHelper.CheckPass, LoginHelper.CheckStatusActive);

            if (result == LoginResult.Success)
            {
                return base.Redirect("/DFourth/Index");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Logout()
        {
            //base.HttpContext.SignOutAsync().Wait();
            UserManagerCore.UserLogout(this.HttpContext);
            return this.Redirect("~/DFourth/Login");
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
