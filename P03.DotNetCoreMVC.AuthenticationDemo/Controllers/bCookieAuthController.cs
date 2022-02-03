//using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using P03.DotNetCoreMVC.AuthenticationDemo.AuthUtility;
using Microsoft.AspNetCore.Authentication;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Controllers
{
    public class bCookieAuthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }



        [AllowAnonymous]
        public async Task<IActionResult> Login(string name, string password)
        {
            //.net core MVC Cookie,  keep 30 minutes

            var claimIdentity = new ClaimsIdentity("Custom");
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, name));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, "xxxx@gmail.com"));

            await base.HttpContext.SignInAsync("CustomScheme", new ClaimsPrincipal(claimIdentity),
                new AuthenticationProperties
                {
                    ExpiresUtc = System.DateTime.UtcNow.AddMinutes(30)
                });


            return new JsonResult(new
            {
                Result = true,
                Message = "Login Successfully!"
            });
        }


        public async Task<IActionResult> Authentication()
        {
            var result = await base.HttpContext.AuthenticateAsync("CustomScheme");
            if (result?.Principal != null)
            {
                base.HttpContext.User = result.Principal;

                return new JsonResult(
                    new
                    {
                        Result = true,
                        Message = $"Authenticate Successfully, has user: {base.HttpContext.User.Identity.Name}"
                    });
            }
            else
            {
                return new JsonResult(
                    new
                    {
                        Result = true,
                        Message = $"Authenticate Failed"
                    });

            }


        }








    }
}
