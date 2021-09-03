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

        #region Polling

        private static int ISeed = 0;

        #endregion


        /// <summary>
        /// https://localhost:44322/etestapi/CallServiceFromConsul
        /// </summary>
        /// <returns></returns>
        public IActionResult CallServiceFromConsul()
        {
            List<CurrentUserCore> userList = new List<CurrentUserCore>();

            /*
             * http://localhost:44357/api/fusersapi/Get
             *
             * http://localhost:44358/api/fusersapi/Get
             */


            string url = "http://UserServiceGroup/api/fusersapi/Get";
            string resultUrl;
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

                var servicelist = consulDictionary.Where(k =>
                    k.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase));

                var serviceArray = servicelist.ToArray();
                KeyValuePair<string, AgentService> targetService = new KeyValuePair<string, AgentService>();


                #region get AgentService from the consul

                //randomly get url address and port
                targetService = serviceArray[new Random().Next(0, serviceArray.Length)];


                string hostNew = $"{targetService.Value.Address}:{targetService.Value.Port}";
                //resultUrl = url.Replace(groupName, hostNew,StringComparison.OrdinalIgnoreCase);
                resultUrl = uri.Scheme + "://" + hostNew + "/api/fusersapi/Get";


                //get result from HttpClient
                string result = HttpClientHelper.InvokeApi(resultUrl);
                userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CurrentUserCore>>(result);

                #endregion


                ViewBag.Url = resultUrl;
                ViewBag.Data = result;
                ViewBag.Users = userList;
            }

            return View();
        }






        /// <summary>
        /// https://localhost:44322/etestapi/CallServiceFromConsulWithWeight
        /// </summary>
        /// <returns></returns>
        public IActionResult CallServiceFromConsulWithWeight()
        {
            List<CurrentUserCore> userList = new List<CurrentUserCore>();

            /*
             * http://localhost:44357/api/fusersapi/Get
             *
             * http://localhost:44358/api/fusersapi/Get
             */

            string url = "http://UserServiceGroup/api/fusersapi/Get";
            string resultUrl;
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

                var servicelist = consulDictionary.Where(k =>
                    k.Value.Service.Equals(groupName, StringComparison.OrdinalIgnoreCase));

                List<KeyValuePair<string, AgentService>> serviceArray = new List<KeyValuePair<string, AgentService>>();

                KeyValuePair<string, AgentService> targetService = new KeyValuePair<string, AgentService>();


                #region get AgentService from the consul

                //build new dictionary of services based on the tag in the service
                foreach (var pair in servicelist)
                {
                    int count = int.Parse(pair.Value.Tags?[0]);

                    for (int i = 0; i < count; i++)
                    {
                        serviceArray.Add(new KeyValuePair<string, AgentService>(pair.Key,pair.Value));
                    }
                }

                //randomly get url address and port
                targetService = serviceArray[new Random().Next(0, serviceArray.Count)];

                string hostNew = $"{targetService.Value.Address}:{targetService.Value.Port}";
                //resultUrl = url.Replace(groupName, hostNew,StringComparison.OrdinalIgnoreCase);
                resultUrl = uri.Scheme + "://" + hostNew + "/api/fusersapi/Get";


                //get result from HttpClient
                string result = HttpClientHelper.InvokeApi(resultUrl);
                userList = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CurrentUserCore>>(result);

                #endregion


                ViewBag.Url = resultUrl;
                ViewBag.Data = result;
                ViewBag.Users = userList;
            }

            return View();
        }



















    }
}