using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.AuthenticationDemo.JWT_RS.Controllers
{
    public class aJWTRSController : Controller
    {

        private readonly ILogger<HomeController> _logger;

        public aJWTRSController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        //https://localhost:5001/ajwtrs/index
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
