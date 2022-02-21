using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace P03.DotNetCoreMVC.AuthenticationDemo.JWT.Controllers
{
    //https://localhost:44369/aJWT
    public class aJWTController : Controller
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
                Message = "aJWT IndexRole "
            });

        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult IndexPolicy()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "aJWT IndexPolicy "
            });

        }

        [Authorize(Policy = "MailPolicy")]
        public IActionResult IndexEmails()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "aJWT IndexEmails "
            });

        }



        public IActionResult Online()
        {
            return new JsonResult
            (
                new
                {
                    Result = true,
                    Message ="Online"
                }
            );
        }


    }
}
