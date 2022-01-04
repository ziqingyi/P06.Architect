using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class aFirstTestController : ControllerBase
    {

        private readonly ILogger<aFirstTestController> _logger;

        public aFirstTestController(ILogger<aFirstTestController> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(aFirstTestController)} is initialized....");
        }

        [HttpGet]
        [Route("GetString")]
        public string GetString()
        {
            _logger.LogInformation("GetString");

            return "getString Result";
        }


        [HttpGet]
        [Route("GetInt")]
        public int GetInt(int i)
        {
            _logger.LogInformation($"GetInt, param is ：{i}");
            return i;
        }


        [HttpGet]
        [Route("GetJson")]
        public string GetJson(int id, string name)
        {
            _logger.LogInformation($"GetJson, params are ：{id}, {name}");
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                Id = id,
                Name = name
            });
        }










    }
}
