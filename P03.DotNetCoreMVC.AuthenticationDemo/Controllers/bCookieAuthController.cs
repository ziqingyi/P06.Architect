using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using P03.DotNetCoreMVC.AuthenticationDemo.AuthUtility;
using Microsoft.AspNetCore.Authentication;
using P03.DotNetCoreMVC.Utility.Filters.AuthFilters;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Controllers
{
    //use CustomAuthenticationHandler  without app.UseAuthentication(); and app.UseAuthorization();  
    public class bCookieAuthController : Controller
    {
        public IActionResult Index()
        {
            var user = base.HttpContext.User;

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

        public async Task<IActionResult> AuthenticationAndAuthorization()
        {

            #region Authentication

            var result = await base.HttpContext.AuthenticateAsync("CustomScheme");
            if (result?.Principal != null)
            {
                base.HttpContext.User = result.Principal;

            }
            else
            {
                return new JsonResult(
                    new
                    {
                        Result = true,
                        Message = $"Authenticate Failed, do not has user: {base.HttpContext.User.Identity.Name}"
                    });
            }

            #endregion

            #region Authorization

            var user = base.HttpContext.User;
            if(user?.Identity?.IsAuthenticated?? false)
            {
                if (user.Identity.Name.Equals("admin", StringComparison.OrdinalIgnoreCase))
                {
                    await base.HttpContext.ForbidAsync("CustomScheme");
                    return new JsonResult(
                        new
                        {
                            Result = true,
                            Message = $"Authorise successfully,  {user.Identity.Name} has authorization",
                            Html = "Hello!"
                        });
                }
                else
                {
                    return new JsonResult(
                        new
                        {
                            Result = true,
                            Message = $"Authorise failed, {user.Identity.Name} do not has authorization"
                        });
                }
            }
            else
            {
                await base.HttpContext.ChallengeAsync("CustomScheme");

                return new JsonResult(
                    new
                    {
                        Result = true,
                        Message = $"Authorise failed, not logged in "
                    });
            }
            #endregion

        }


        public async Task<IActionResult> Logout()
        {
            await base.HttpContext.SignOutAsync("CustomScheme");
            return new JsonResult(new
            {
                Result = true,
                Message = "Log out successfully "
            });
        }




    }
}
