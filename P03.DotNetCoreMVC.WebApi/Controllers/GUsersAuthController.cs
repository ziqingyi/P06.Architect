
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
using P03.DotNetCoreMVC.Interface.TestServiceInterface;


namespace P03.DotNetCoreMVC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]//must from AspNetCore
    public class GUsersAuthController : ControllerBase
    {


        #region Data

        private List<CurrentUserCore> _usersList;

        #endregion

        #region Identity

        private ILoggerFactory _Factory = null;
        private ILogger<GUsersAuthController> _logger = null;
        private IUserService _userService = null;
        //test AOP
        private IA _IA = null;

        public GUsersAuthController(ILoggerFactory loggerFactory,
            //ILogger<FUsersApiController> logger,
            IUserService userService,
            IA a
        )
        {
            this._Factory = loggerFactory;
            this._logger = new Logger<GUsersAuthController>(this._Factory);

            this._userService = userService;
            this._IA = a;

            _usersList = this._userService.Query<User>(u => u.Id < 20)
                .Select(u => new CurrentUserCore()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Account = u.Account,
                    Password = u.Password,
                    Email = u.Email,
                    State = u.State == 1 ? true : false,
                    Role = "",
                    LastLoginTime = u.LastLoginTime ?? DateTime.Now,
                    CreateTime = u.CreateTime,
                    Datas = null
                }).ToList();

        }
        #endregion


        #region HttpGet

        //https://localhost:44357/api/GUsersAuth
        
        // this is the rest way
        //GET api/User
        [HttpGet]
        public IEnumerable<CurrentUserCore> Get()
        {
            this._logger.LogInformation("This is GUsersAuthController  Get method");
            return _usersList;
        }

        [HttpGet("{id:int}")]
        public CurrentUserCore Get(int id)
        {
            string idParam = base.HttpContext.Request.Query["Id"];

            CurrentUserCore u = _usersList.FirstOrDefault(user => user.Id == id);
            if (u == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            return u;
        }

        [HttpGet("{name}")]
        [AllowAnonymous]
        public IEnumerable<CurrentUserCore> Get(string name)
        {
            //throw new Exception("23213131");//test exception
            string userNameParam = base.HttpContext.Request.Query["name"];

            return _usersList.Where(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
        }







        #endregion


    }
}
