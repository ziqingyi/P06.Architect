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

            var claimIdentity = new ClaimsIdentity("Custom");
            claimIdentity.AddClaim(new Claim(ClaimTypes.Name, name));
            claimIdentity.AddClaim(new Claim(ClaimTypes.Email, "xxxx@gmail.com"));

            await base.HttpContext.SignInAsync(new ClaimsPrincipal(claimIdentity),
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
