using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.Areas.CustomPlugin.Controllers
{
    [Area("CustomPlugin")]
    [Route("CustomPlugin/[controller]/[action]")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
