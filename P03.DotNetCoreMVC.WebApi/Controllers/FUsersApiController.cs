﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using P03.DotNetCoreMVC.Utility.Models;
using P03.DotNetCoreMVC.Interface;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using System.Web.Http;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;

namespace P03.DotNetCoreMVC.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FUsersApiController : ControllerBase
    {


        #region Data

        private List<CurrentUserCore> _usersList;

        #endregion

        #region Identity

        private ILoggerFactory _Factory = null;
        private ILogger<FUsersApiController> _logger = null;
        private IUserService _userService = null;
        //test AOP
        private IA _IA = null;

        public FUsersApiController(ILoggerFactory loggerFactory,
            //ILogger<FUsersApiController> logger,
            IUserService userService,
            IA a
        )
        {
            this._Factory = loggerFactory;
            this._logger = new Logger<FUsersApiController>(this._Factory);

            this._userService = userService;
            this._IA = a;

            _usersList = this._userService.Query<User>(u => u.Id < 20)
                .OrderBy(u=>u.Id)
                .Skip(1)
                .Take(5)
                .Select(u => new CurrentUserCore()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Account = u.Account,
                    Password = u.Password,
                    Email = u.Email,
                    State = u.State==1?true:false,
                    Role = "",
                    LastLoginTime = u.LastLoginTime?? DateTime.Now,
                    CreateTime = u.CreateTime,
                    Datas = null
                }).ToList();

        }

        #endregion

        #region HttpGet

        // this is the rest way. but for test, we have multiple get names. 
        //GET api/User
        [HttpGet]
        public IEnumerable<CurrentUserCore> Get()
        {
            this._logger.LogInformation("This is FUsersApiController  Get method");
            return _usersList;
        }

        [HttpGet]
        public CurrentUserCore GetUserByID(int id)
        {
            //throw new Exception("23213131");
            string idParam = base.HttpContext.Request.Query["userId"];

            CurrentUserCore u = _usersList.FirstOrDefault(user => user.Id == id);
            if (u == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return u;
        }

        [HttpGet]
        //[CustomBasicAuthorize] //if place on method, only works for this method. 
        public IEnumerable<CurrentUserCore> GetUserByName(string username)
        {
            //throw new Exception("23213131");//test exception
            string userNameParam = base.HttpContext.Request.Query["userName"];
            
            return _usersList.Where(p => string.Equals(p.Name, username, StringComparison.OrdinalIgnoreCase));
        }

        [HttpGet]
        public IEnumerable<CurrentUserCore> GetUserByNameId(string username, int id)
        {
            #region if cors is not enabled, add to header directly, only for this method

            //base.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin","*");

            #endregion

            string idParam = base.HttpContext.Request.Query["userId"];
            string userNameParam = base.HttpContext.Request.Query["userName"]; 
            _IA.Log(idParam,userNameParam);
            return _usersList.Where(p => string.Equals(p.Name, username, StringComparison.OrdinalIgnoreCase));
        }

        //btnGet5
        [HttpGet]
        public IEnumerable<CurrentUserCore> GetUserByModel(CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string userNameParam = base.HttpContext.Request.Query["userName"];
            string email = base.HttpContext.Request.Query["email"];

            return _usersList;
        }
        //btnGet6
        [HttpGet]
        public IEnumerable<CurrentUserCore> GetUserByModelUri([FromUri] CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string userNameParam = base.HttpContext.Request.Query["userName"];
            string email = base.HttpContext.Request.Query["email"];

            return _usersList;
        }
        //btnGet7
        [HttpGet]
        public IEnumerable<CurrentUserCore> GetUserByModelSerialize(string userstring)
        {
            CurrentUserCore user = JsonConvert.DeserializeObject<CurrentUserCore>(userstring);
            return _usersList;
        }
        //btnGet8
        public IEnumerable<CurrentUserCore> GetUserByModelSerializeWithoutGet(string userstring)
        {
            CurrentUserCore user = JsonConvert.DeserializeObject<CurrentUserCore>(userstring);
            return _usersList;
        }
        //not begin with Get and no attribute([HttpGet]/[HttpPost]/[HttpPut]/[HttpDelete]), will return 405, not sure which request.
        public IEnumerable<CurrentUserCore> NoGetUserByModelSerializeWithoutGet(string userstring)
        {
            CurrentUserCore user = JsonConvert.DeserializeObject<CurrentUserCore>(userstring);
            return _usersList;
        }

        #endregion


        #region HttpPost
        //
        [HttpPost]
        public CurrentUserCore RegisterNone()
        {
            return _usersList.FirstOrDefault();
        }
        //btnPost1
        [HttpPost]
        public CurrentUserCore RegisterNoKey([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["UserID"];

            var user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        //btnPost2
        [HttpPost]
        public CurrentUserCore Register([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["ID"];
            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }
        //btnPost3
        [HttpPost]
        public CurrentUserCore RegisterUser(CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Query["UserID"];
            string nameParam = base.HttpContext.Request.Query["userName"];
            string emailParam = base.HttpContext.Request.Query["userEmail"];

            return user;
        }


        [HttpPost]
        public string RegisterObject(JObject jData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = jData;
            JObject juser = json.User;
            string info = json.Info;

            var user = juser.ToObject<CurrentUserCore>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }


        [HttpPost]
        public string RegisterObjectDynamic(dynamic dynamicData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;

            CurrentUserCore user = juser.ToObject<CurrentUserCore>();
            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }

        #endregion



        #region HttpPut

        [HttpPut]
        public CurrentUserCore RegisterNonPut()
        {
            CurrentUserCore u = _usersList.FirstOrDefault();
            return u;
        }


        [HttpPut]
        public CurrentUserCore RegisterNoKeyPut([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];

            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }


        [HttpPut]
        public CurrentUserCore RegisterPut([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];

            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        [HttpPut]
        public CurrentUserCore RegisterUserPut(CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string nameParam = base.HttpContext.Request.Query["userName"];
            string emailParam = base.HttpContext.Request.Query["userEmail"];

            return user;
        }

        [HttpPut]
        public string RegisterObjectPut(JObject jData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = jData;
            JObject juser = json.User;
            string info = json.Info;

            CurrentUserCore user = juser.ToObject<CurrentUserCore>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }

        [HttpPut]
        public string RegisterObjectDynamicPut(dynamic dynamicData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Query["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;

            CurrentUserCore user = juser.ToObject<CurrentUserCore>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }


        #endregion


        #region HttpDelete

        [HttpDelete]
        public CurrentUserCore RegisterNoneDelete()
        {
            CurrentUserCore u = _usersList.FirstOrDefault();
            return u;
        }

        [HttpDelete]
        public CurrentUserCore RegisterNoKeyDelete([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        [HttpDelete]
        public CurrentUserCore RegisterDelete([FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];

            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }

        [HttpDelete]
        public CurrentUserCore RegisterUserDelete(CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string nameParam = base.HttpContext.Request.Query["userName"];
            string emailParam = base.HttpContext.Request.Query["userEmail"];

            return user;
        }

        [HttpDelete]
        public string RegisterObjectDynamicDelete(dynamic dynamicData)
        {
            string idParam = base.HttpContext.Request.Query["User[userId]"];
            string nameParam = base.HttpContext.Request.Query["User[userName]"];
            string emailParam = base.HttpContext.Request.Query["info"];

            dynamic json = dynamicData;
            JObject juser = json.User;
            string info = json.Info;
            CurrentUserCore user = juser.ToObject<CurrentUserCore>();

            string result = string.Format("{0}_{1}_{2}_{3}", user.Id, user.Name, user.Email, info);
            return result;
        }




        #endregion














    }
}
