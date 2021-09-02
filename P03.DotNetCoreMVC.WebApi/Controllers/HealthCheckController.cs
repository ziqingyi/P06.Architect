using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;

namespace P03.DotNetCoreMVC.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {

        private readonly IConfiguration _iConfiguration;
        private readonly ILoggerFactory _loggerFactory;
        private readonly ILogger<HealthCheckController> _logger;

        public HealthCheckController(ILoggerFactory loggerFactory,
            //ILogger<HealthCheckController> logger, 
            IConfiguration configuration)
        {
            this._loggerFactory = loggerFactory;
            this._logger = new Logger<HealthCheckController>(loggerFactory); ;
            this._iConfiguration = configuration;
        }

        [HttpGet]
        public IActionResult Index()
        {
            this._logger.LogInformation("This is HealthCheckController  Index method");

            return Ok();
        }






    }
}
