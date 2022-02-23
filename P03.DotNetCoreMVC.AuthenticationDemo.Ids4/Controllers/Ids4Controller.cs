using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Ids4.Controllers
{
    public class Ids4Controller : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
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
                Message = "Ids4Controller IndexPolicy "
            });

        }

        [Authorize(Policy = "MailPolicy")]
        public IActionResult IndexEmails()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Ids4Controller IndexEmails "
            });

        }

        //[AllowAnonymous]
        //public IActionResult IndexToken()
        //{
        //    return View();
        //}

        //[AllowAnonymous]
        //public IActionResult IndexCodeToken()
        //{
        //    
        //    return View();
        //}



    }
}
