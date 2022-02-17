using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.AuthenticationDemo.JWT.Controllers
{
    public class aJWTController : Controller
    {
        public IActionResult Index()
        {
            //return new JsonResult(new
            //{
            //    Result = true,
            //    Message = "Log out Successfully"
            //});



            return View();
        }
    }
}
