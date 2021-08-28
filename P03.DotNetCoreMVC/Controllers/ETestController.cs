using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.Controllers
{
    public class ETestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}