using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Controllers
{
    public class aCookieTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        public IActionResult Login(string name, string password)
        {
            //.net core MVC Cookie, use extend method, keep 30 minutes
            base.HttpContext.SetCookies("CurrentUser",
                Newtonsoft.Json.JsonConvert.SerializeObject(currentUser));
        }


    }
}
