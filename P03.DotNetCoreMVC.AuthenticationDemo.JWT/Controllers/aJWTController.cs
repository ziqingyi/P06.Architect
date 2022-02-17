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
            return new JsonResult(new
            {
                Result = true,
                Message = "aJWT index "
            });

        }
        [Authorize(Policy = "Admin")]
        public IActionResult IndexRole()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "aJWT index "
            });

        }
        [Authorize(Policy = "AdminPolicy")]
        public IActionResult IndexPolicy()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "aJWT index "
            });

        }

        [Authorize(Policy = "MultiEmail")]
        public IActionResult IndexEmails()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "aJWT index "
            });

        }
    }
}
