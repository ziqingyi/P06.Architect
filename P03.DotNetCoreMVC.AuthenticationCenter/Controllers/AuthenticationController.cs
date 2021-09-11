using Microsoft.AspNetCore.Mvc;
using P03.DotNetCoreMVC.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility;
using P03.DotNetCoreMVC.Interface;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {

        LoginHelper loginHelper; 

        public AuthenticationController(IUserService userService)
        {
            loginHelper= new LoginHelper(userService);

        }

        [Route("Get")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>() { 1, 2, 3, 4, 6, 7 };
        }

        [HttpPost]
        public string Login(string name, string password)
        {
            LoginResult result = UserManagerCore.ApiLogin(name, password,
                loginHelper.GetUser, loginHelper.CheckPass, loginHelper.CheckStatusActive);

            if (result == LoginResult.Success)
            {
                string token = "";


            }
            else
            {
                
            }


            return "";
        }





    }
}
