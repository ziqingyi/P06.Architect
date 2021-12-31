using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.WebApi2.Controllers
{
    public class aFirstTestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
