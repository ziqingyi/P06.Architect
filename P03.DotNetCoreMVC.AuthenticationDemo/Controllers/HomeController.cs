using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
