using IdentityModel;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationDemo.Controllers
{
    [Authorize]
    public class cSysAuthController : Controller
    {

        public IActionResult Index()
        {
            //system will assign with [Authorize] and app.UseAuthorization(); 
            var user = base.HttpContext.User;

            return View();
        }



        [AllowAnonymous]
        public async Task<IActionResult> Login(string name, string password)
        {

            #region normal claim types

            var claimIdentity = new ClaimsIdentity("Cookie");
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, name));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, "xxxx@gmail.com"));

            #endregion

            #region Jwt claim types, shorter than ClaimTypes

            var claimIdentity2 = new ClaimsIdentity("Cookie");
            claimIdentity2.AddClaim(new Claim(JwtClaimTypes.Name, name));
            claimIdentity2.AddClaim(new Claim(JwtClaimTypes.Email, "yyyy@gmail.com"));

            #endregion




            await base.HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity2),
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








        public async Task<IActionResult> Logout()
        {
            await base.HttpContext.SignOutAsync();
            return new JsonResult(new
            {
                Result = true,
                Message = "Log out successfully "
            });
        }





    }
}
