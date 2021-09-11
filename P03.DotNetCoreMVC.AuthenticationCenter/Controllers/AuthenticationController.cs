using Microsoft.AspNetCore.Mvc;
using P03.DotNetCoreMVC.Utility.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility;
using P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.JWTUtility;
using P03.DotNetCoreMVC.Interface;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;

namespace P03.DotNetCoreMVC.AuthenticationCenter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : Controller
    {
        #region Identity

        private LoginHelper loginHelper;
        private ILoggerFactory _Factory = null;
        private ILogger<AuthenticationController> _logger = null;
        private IUserService _userService = null;
        private IJWTService _iJwtService;
        public AuthenticationController(IUserService userService,
            IConfiguration configuration,
            ILoggerFactory loggerFactory,
            IJWTService JwtService)
        {
            this._Factory = loggerFactory;
            this._logger = new Logger<AuthenticationController>(this._Factory);
            this._userService = userService;
            this._iJwtService = JwtService;

            loginHelper = new LoginHelper(userService);
        }
        
        #endregion


        [Route("Get")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>() { 1, 2, 3, 4, 6, 7 };
        }

        [Route("Login")]
        [HttpPost]
        public string Login(string name, string password)
        {
            LoginResult result = UserManagerCore.ApiLogin(name, password,
                loginHelper.GetUser, loginHelper.CheckPass, loginHelper.CheckStatusActive);

            if (result == LoginResult.Success)
            {
                string token = this._iJwtService.GetToken(name);

                string jToken = JsonConvert.SerializeObject(new
                {
                    result = true,
                    token
                });
                return jToken;
            }
            else
            {

                string jToken = JsonConvert.SerializeObject(new
                {
                    result = false,
                    token =""
                });
                return jToken;


            }


        }





    }
}
