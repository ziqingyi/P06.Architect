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





    }
}