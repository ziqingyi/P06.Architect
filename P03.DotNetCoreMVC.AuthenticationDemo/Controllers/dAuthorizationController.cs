using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Controllers
{
    [Authorize]
    public class dAuthorizationController : Controller
    {
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }


        [AllowAnonymous]
        public async Task<IActionResult> Login(string name, string password, string role="Admin")
        {
            //The default value used for CookieAuthenticationOptions.AuthenticationScheme
            //public const string AuthenticationScheme = "Cookies";

            #region normal claim types

            var claimIdentity = new ClaimsIdentity("Cookie");
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, name));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, "xxxx@gmail.com"));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Role, role));

            #endregion

            await base.HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimIdentity),
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




        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await base.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return new JsonResult(
                new
                {
                    Result = true,
                    Message = "Log out Successfully"
                }) ;

        }

        #region pages need to authorize

        [Authorize(Roles = "Admin")]
        public IActionResult InfoAdmin()
        {
            return View();
        }

        [Authorize(AuthenticationSchemes = "Cookies")]
        public IActionResult InfoScheme()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of Scheme"
            }); 
        }

        [Authorize(Roles = "Admin,User")]
        public IActionResult InfoEveryone()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of Everyone"
            });
        }




        #endregion







    }
}
