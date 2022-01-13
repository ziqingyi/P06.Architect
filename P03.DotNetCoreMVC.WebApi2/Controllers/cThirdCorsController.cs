using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Utility.Filters;

namespace P03.DotNetCoreMVC.WebApi2.Controllers
{

    /*
     add in controller filter or services.AddMvc, or add directly in base.HttpContext.Response.Headers.
     
     */


    [Route("api/[controller]")]
    [ApiController]
    [CustomCorsFilterAttribute]
    public class cThirdCorsController : ControllerBase
    {
        private readonly ILogger<cThirdCorsController> _logger;

        public cThirdCorsController(ILogger<cThirdCorsController> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(cThirdCorsController)} is initialized....");
        }


        [HttpGet]
        [Route("GetCrossDomainData1")]
        //[AllowAnonymous]
        public string GetCrossDomainData1()
        {
            //base.HttpContext.Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    id = 123,
                    Name = "name",
                    Description = "api cross domain"
                });
        }



        [HttpGet]
        [Route("GetCrossDomainData2")]
        //[AllowAnonymous]
        public string GetCrossDomainData2()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(
                new
                {
                    id = 123,
                    Name = "name",
                    Description = "api cross domain"
                });
        }






    }
}
