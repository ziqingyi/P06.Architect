using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using P03.DotNetCoreMVC.Utility.ApiHelper;
using P03.DotNetCoreMVC.Utility.Models;

namespace P03.DotNetCoreMVC.Controllers
{
    public class ETestApiController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InfoFromUriHttpClient()
        {
            List<CurrentUserCore> userList = new List<CurrentUserCore>();

            string url = "http://localhost:44357/api/fusersapi/Get";

            string result = HttpClientHelper.InvokeApi(url);

            userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CurrentUserCore>>(result);


            ViewBag.Url = url;
            ViewBag.Data = result;
            ViewBag.Users = userList;


            return View();
        }







    }
}