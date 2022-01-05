using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Utility.Filters;
using System;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace P03.DotNetCoreMVC.WebApi2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bSecondFilterTestController : ControllerBase
    {

        private readonly ILogger<bSecondFilterTestController> _logger;

        public bSecondFilterTestController(ILogger<bSecondFilterTestController> logger)
        {
            _logger = logger;
            _logger.LogInformation($"{nameof(bSecondFilterTestController)} is initialized....");
        }



        [HttpGet]        
        [Route("GetDateTime")]
        [CustomResourceFilterAttribute]
        public string GetDateTime()
        {
            return $"Time is   {DateTime.Now}";
        }

        [HttpGet]
        [Route("GetInfoByParamter")]
        [CustomActionFilterAttribute]
        public string GetInfoByParamter(int id, string Name)
        {
            return $"this is Id={id},Name={Name}";
        }



        #region default

        // GET: api/<bSecondFilterTestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<bSecondFilterTestController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<bSecondFilterTestController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<bSecondFilterTestController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<bSecondFilterTestController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        #endregion


    }
}
