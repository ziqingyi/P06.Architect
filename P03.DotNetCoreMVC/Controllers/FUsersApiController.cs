﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using P03.DotNetCoreMVC.Interface.TestServiceInterface;
using P03.DotNetCoreMVC.Interface;
using P03.DotNetCoreMVC.Utility.Models;
using FromBodyAttribute = Microsoft.AspNetCore.Mvc.FromBodyAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using FromBody = Microsoft.AspNetCore.Mvc.FromBodyAttribute;


namespace P03.DotNetCoreMVC.Controllers
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
        private ITestServiceA _ITestServiceA = null;
        private ITestServiceB _ITestServiceB = null;
        private ITestServiceC _ITestServiceC = null;
        private ITestServiceD _ITestServiceD = null;
        private IUserService _userService = null;

        //test AOP
        private IA _IA = null;


        public FUsersApiController(ILoggerFactory loggerFactory,
            ILogger<FUsersApiController> logger,
            
            ITestServiceA testServiceA,
            ITestServiceB testServiceB,
            ITestServiceC testServiceC,
            ITestServiceD testServiceD,

            IUserService userService,
            
            IA a
        )
        {
            this._Factory = loggerFactory;
            this._logger = logger;
            this._ITestServiceA = testServiceA;
            this._ITestServiceB = testServiceB;
            this._ITestServiceC = testServiceC;
            this._ITestServiceD = testServiceD;
            this._IA = a;

            this._userService = userService;


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
        //btnGet1
        // this is the rest way. but for test, we have multiple get names. 
        //https://localhost:44357/api/FUsersApi/get
        //GET api/User
        [HttpGet]
        public IEnumerable<CurrentUserCore> Get()
        {

            return _usersList;
        }

        //btnGet2
        [HttpGet]
        public CurrentUserCore GetUserByID(int id)
        {
            //throw new Exception("23213131");
            string idParam = base.HttpContext.Request.Query["Id"];

            CurrentUserCore u = _usersList.FirstOrDefault(user => user.Id == id);
            if (u == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return u;
        }

        //btnGet3
        [HttpGet]
        //[CustomBasicAuthorize] //if place on method, only works for this method. 
        public IEnumerable<CurrentUserCore> GetUserByName(string username)
        {
            //throw new Exception("23213131");//test exception
            string userNameParam = base.HttpContext.Request.Query["userName"];
            
            return _usersList.Where(p => string.Equals(p.Name, username, StringComparison.OrdinalIgnoreCase));
        }

        //btnGet4
        [HttpGet]
        public IEnumerable<CurrentUserCore> GetUserByNameId(string username, int id)
        {
            string idParam = base.HttpContext.Request.Query["userId"];
            string userNameParam = base.HttpContext.Request.Query["userName"]; 
            _IA.Log(idParam,userNameParam);
            return _usersList.Where(p => string.Equals(p.Name, username, StringComparison.OrdinalIgnoreCase));
        }

        /// ///////////////////////////////////////////////

        //btnGet5
        [HttpGet]
        public IEnumerable<CurrentUserCore> GetUserByModel([FromQuery]CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Query["Id"];
            string userNameParam = base.HttpContext.Request.Query["Name"];
            string email = base.HttpContext.Request.Query["Email"];

            return _usersList;
        }
        //btnGet6, core with [FromHeader]
        [HttpGet]
        public IEnumerable<CurrentUserCore> GetUserByModelUri([FromHeader]CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Query["Id"];
            string userNameParam = base.HttpContext.Request.Query["Name"];
            string email = base.HttpContext.Request.Query["Email"];

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

        //btnGet9
        //not begin with Get and no attribute([HttpGet]/[HttpPost]/[HttpPut]/[HttpDelete]), request accepted..
        public IEnumerable<CurrentUserCore> NoGetUserByModelSerializeWithoutGet(string userstring)
        {
            CurrentUserCore user = JsonConvert.DeserializeObject<CurrentUserCore>(userstring);
            return _usersList;
        }

        #endregion


        #region HttpPost
        //btnPost0
        [HttpPost]
        public CurrentUserCore RegisterNone()
        {
            return _usersList.FirstOrDefault();
        }
        //btnPost1
        [HttpPost]
        public CurrentUserCore RegisterNoKey(int id)
        {
            string idParam = base.HttpContext.Request.Form[""]; //get value from form

            var user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }
        //btnPost2
        [HttpPost]
        public CurrentUserCore RegisterWithDataKey([FromForm]int id) //must get id from Form
        {
            string idParam = base.HttpContext.Request.Form["Id"];//get value from form
            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == int.Parse(idParam));

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return user;
        }
        //btnPost3, binding to Form
        [HttpPost]
        public CurrentUserCore RegisterUserForm([FromForm]CurrentUserCore user)
        {
            string idParam = base.HttpContext.Request.Form["Id"];
            string nameParam = base.HttpContext.Request.Form["Name"];
            string emailParam = base.HttpContext.Request.Form["Email"];

            return user;
        }

        //btnPost4
        [HttpPost]
        public CurrentUserCore RegisterUser([FromBodyAttribute]string user)
        {
            //string idParam = base.HttpContext.Request.Form["Id"];
            //string nameParam = base.HttpContext.Request.Form["Name"];
            //string emailParam = base.HttpContext.Request.Form["Email"];

            CurrentUserCore res = JsonConvert.DeserializeObject<CurrentUserCore>(user);
            return res;
        }



        //btnPost5
        [HttpPost]
        public string RegisterObject(JObject jData)
        {
            string idParam = base.HttpContext.Request.Form["userPost[Id]"];
            string nameParam = base.HttpContext.Request.Form["userPost[Name]"];
            string emailParam = base.HttpContext.Request.Form["userPost[Email]"];
            string infoParam = base.HttpContext.Request.Form["info"];

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
            string idParam = base.HttpContext.Request.Form["userPost[Id]"];
            string nameParam = base.HttpContext.Request.Form["userPost[Name]"];
            string emailParam = base.HttpContext.Request.Form["userPost[Email]"];
            string infoParam = base.HttpContext.Request.Form["info"];

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
        public CurrentUserCore RegisterNoKeyPut([System.Web.Http.FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Form["userId"];

            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }


        [HttpPut]
        public CurrentUserCore RegisterPut([System.Web.Http.FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Form["userId"];

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
            string idParam = base.HttpContext.Request.Form["userId"];
            string nameParam = base.HttpContext.Request.Form["userName"];
            string emailParam = base.HttpContext.Request.Form["userEmail"];

            return user;
        }

        [HttpPut]
        public string RegisterObjectPut(JObject jData)
        {
            string idParam = base.HttpContext.Request.Form["User[userId]"];
            string nameParam = base.HttpContext.Request.Form["User[userName]"];
            string emailParam = base.HttpContext.Request.Form["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Form["info"];

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
            string idParam = base.HttpContext.Request.Form["User[userId]"];
            string nameParam = base.HttpContext.Request.Form["User[userName]"];
            string emailParam = base.HttpContext.Request.Form["User[userEmail]"];
            string infoParam = base.HttpContext.Request.Form["info"];

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
        public CurrentUserCore RegisterNoKeyDelete([System.Web.Http.FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Form["userId"];
            CurrentUserCore user = _usersList.FirstOrDefault(u => u.Id == id);

            if (user == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return user;
        }

        [HttpDelete]
        public CurrentUserCore RegisterDelete([System.Web.Http.FromBody] int id)
        {
            string idParam = base.HttpContext.Request.Form["userId"];

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
            string idParam = base.HttpContext.Request.Form["userId"];
            string nameParam = base.HttpContext.Request.Form["userName"];
            string emailParam = base.HttpContext.Request.Form["userEmail"];

            return user;
        }

        [HttpDelete]
        public string RegisterObjectDynamicDelete(dynamic dynamicData)
        {
            string idParam = base.HttpContext.Request.Form["User[userId]"];
            string nameParam = base.HttpContext.Request.Form["User[userName]"];
            string emailParam = base.HttpContext.Request.Form["info"];

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
