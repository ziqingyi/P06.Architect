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
        public async Task<IActionResult> Login(string name, string password)
        {
            //The default value used for CookieAuthenticationOptions.AuthenticationScheme
            //public const string AuthenticationScheme = "Cookies";
            string role;
            if(name.ToLower().Contains("admin"))
            {
                role = "Admin";
            }
            else
            {
                role = "UserRole";
            }


            #region normal claim types

            var claimIdentity = new ClaimsIdentity("Cookie");
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, name));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, "xxxx@outlook.com"));
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

        #region pages need to authorize by Role

        [Authorize(Roles = "Admin")]
        public IActionResult InfoAdmin()
        {
            return View();
        }


        [Authorize(Roles = "User")]
        public IActionResult InfoUser()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of Everyone"
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

        [Authorize(AuthenticationSchemes = "Cookies")]
        public IActionResult InfoScheme()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of Scheme"
            }); 
        }


        #endregion


        #region  pages need to authorize by Policy

        [Authorize(AuthenticationSchemes = "Cookies", Policy = "AdminPolicy")]
        public IActionResult InfoAdminPolicy()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of Admin Policy"
            });
        }


        [Authorize(AuthenticationSchemes = "Cookies", Policy = "UserPolicy")]
        public IActionResult InfoUserPolicy()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of User Policy"
            });
        }

        [Authorize(AuthenticationSchemes = "Cookies", Policy = "EmailPolicy")]
        public IActionResult InfoEmail()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of Email Policy"
            });
        }


        [Authorize(AuthenticationSchemes = "Cookies", Policy = "DoubleEmail")]
        public IActionResult InfoDoubleEmail()
        {
            return new JsonResult(new
            {
                Result = true,
                Message = "Information of Double Email Policy"
            });
        }

        #endregion




    }
}
