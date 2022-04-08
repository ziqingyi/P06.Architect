using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Text;
using IdentityModel;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Ids4.Controllers
{
    public class Ids4Controller : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            Console.WriteLine(" * ***********************************************");

            String id_token = base.HttpContext.Request.Cookies["id_token"];
            if (!string.IsNullOrEmpty(id_token))
            {
                var token_parts = id_token.Split('.');
                var header = Encoding.UTF8.GetString(Base64Url.Decode(token_parts[0]));
                var claims = Encoding.UTF8.GetString(Base64Url.Decode(token_parts[1]));
                var sign = Encoding.UTF8.GetString(Base64Url.Decode(token_parts[2]));
                Console.WriteLine("headers: " + header);
                Console.WriteLine("claims: " + claims);
                Console.WriteLine("sign: " + sign);
            }

            foreach (var item in base.HttpContext.User.Identities.First().Claims)
            {
                Console.WriteLine($"{item.Type}:{item.Value}");
            }
            Console.WriteLine("&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&&");

            return View();

        }
        [Authorize(Roles = "Admin")]
        public IActionResult IndexRole()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Ids4Controller IndexRole "
            });

        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult IndexPolicy()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Ids4Controller AdminPolicy "
            });

        }

        [Authorize(Policy = "MailPolicy")]
        public IActionResult IndexEmails()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Ids4Controller MailPolicy "
            });

        }

        [AllowAnonymous]
        public IActionResult IndexToken()
        {
            return View();
        }

        [AllowAnonymous]
        public IActionResult IndexCodeToken()
        {

            return View();
        }



    }
}
