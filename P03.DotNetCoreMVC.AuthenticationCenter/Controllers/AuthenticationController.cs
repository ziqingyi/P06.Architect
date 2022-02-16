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
using P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.JWTUtilityUpgradeV1;
using P03.DotNetCoreMVC.Utility.Models;

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
        private IJWTHSService _iJwtHSService;
        private IJWTRSService _iJwtRSService;
        public AuthenticationController(
            IUserService userService,

            IConfiguration configuration,
            ILoggerFactory loggerFactory,

            IJWTService JwtService,
            IJWTHSService JWTHSService,
            IJWTRSService JWTRSService)
        {
            this._Factory = loggerFactory;
            this._logger = new Logger<AuthenticationController>(this._Factory);
            this._userService = userService;

            //JWT services
            this._iJwtService = JwtService;
            this._iJwtHSService = JWTHSService;
            this._iJwtRSService = JWTRSService;

            loginHelper = new LoginHelper(userService);
        }
        
        #endregion


        [Route("Get")]
        [HttpGet]
        public IEnumerable<int> Get()
        {
            return new List<int>() { 1, 2, 3, 4, 6, 7 };
        }

        //
        [Route("Login")]
        [HttpPost]
        public string Login(string name, string password, string s="")
        {
            CurrentUserCore userInfo = null;
            LoginResult result = UserManagerCore.ApiLogin(name, password,
                loginHelper.GetUser, loginHelper.CheckPass, loginHelper.CheckStatusActive, out userInfo);

            if (result == LoginResult.Success)
            {
                string token = "";

                if(s.Trim() == "")
                {
                    token = this._iJwtService.GetToken(name);
                }
                else if(s.Trim().ToLower() == "hs")
                {
                    token = this._iJwtHSService.GetToken(userInfo);
                }
                else if (s.Trim().ToLower() == "rs")
                {
                    token = this._iJwtRSService.GetToken(userInfo);
                }

                //convert to json
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
