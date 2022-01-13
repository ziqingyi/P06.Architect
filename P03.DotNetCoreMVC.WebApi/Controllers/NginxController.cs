using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace P03.DotNetCoreMVC.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NginxController : Controller
    {


        private readonly ILogger<NginxController> _logger;

        public NginxController(ILogger<NginxController> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(NginxController)} controller init....");
        }

        private static int iCount = 0;

        [HttpGet]
        [Route("GetString")]
        public string GetString()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(new
            {
                AppPort = $"this is Server",
                Visits = iCount++
            });
        }
    }
}
