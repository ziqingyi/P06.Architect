using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Consul;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Utility.ApiHelper;
using P03.DotNetCoreMVC.Utility.Models;

namespace P03.DotNetCoreMVC.Controllers
{
    public class ETestApiController : Controller
    {

        #region Identity

        private readonly ILogger<CThirdController> _logger;
        private readonly ILoggerFactory _loggerFactory;
        public ETestApiController(ILogger<CThirdController> logger,
            ILoggerFactory loggerFactory)
        {
            this._logger = logger;
            this._loggerFactory = loggerFactory;
        }

        #endregion



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult InfoFromUriHttpClient()
        {
            List<CurrentUserCore> userList = new List<CurrentUserCore>();

            string url = "http://localhost:44357/api/fusersapi/Get";

            string result = HttpClientHelper.InvokeApi(url);

            userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CurrentUserCore>>(result);


            ViewBag.Url = url;
            ViewBag.Data = result;
            ViewBag.Users = userList;


            return View();
        }

        public IActionResult InfoFromConsul()
        {
            using (ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            } ))
            {
                var consulDictionary = client.Agent.Services().Result.Response;
                string message = "";

                foreach (KeyValuePair<string, AgentService> serviceResponse in consulDictionary)
                {
                    AgentService agentService = serviceResponse.Value;


                    string agentServiceMsg = $"agent service: {agentService.Address}:{agentService.Port} " +
                                             $"Id:{agentService.ID} {agentService.Service}";

                    this._logger.LogWarning(agentServiceMsg);

                    message += agentServiceMsg + Environment.NewLine;

                }
                base.ViewBag.Message = message;
            }

            return View();
        }

        public IActionResult CallServiceFromConsul()
        {
            /*
             * http://localhost:44357/api/fusersapi/Get
             *
             * http://localhost:44358/api/fusersapi/Get
             */


            string url = "http://UserServiceGroup/api/fusersapi/Get";

            Uri uri = new Uri(url);
            string groupName = uri.Host;



            using (ConsulClient client = new ConsulClient(c =>
            {
                c.Address = new Uri("http://localhost:8500/");
                c.Datacenter = "dc1";
            }))
            {
                var consulDictionary = client.Agent.Services().Result.Response;
                string message = "";

                var list = consulDictionary.Where(k =>
                    k.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase));

                KeyValuePair<string, AgentService> keyValuePair = new KeyValuePair<string, AgentService>();







                base.ViewBag.Message = message;
            }

            return View();
        }



    }
}