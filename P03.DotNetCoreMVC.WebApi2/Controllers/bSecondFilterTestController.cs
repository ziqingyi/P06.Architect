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
    [TypeFilter(typeof(CustomControllerParaFilterAttribute), Order = 5)]//affect all actions in this controller
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
            return $"this is GetInfoByParamter: Id={id},Name={Name}";
        }


        [HttpGet]
        [Route("GetInfoByParamterTypeFilter")]
        [TypeFilter( typeof(CustomActionFilterLogAttribute) )]//attribute Injected by container
        public string GetInfoByParamterTypeFilter(int id, string Name)
        {
            return $"this is GetInfoByParamterTypeFilter:  Id={id},Name={Name}";
        }

        [HttpGet]
        [Route("GetInfoByParamterServiceFilter")]
        [ServiceFilter(typeof(CustomActionFilterLogLogAttribute))]// register with services
        public string GetInfoByParamterServiceFilter(int id, string Name)
        {
            return $"this is GetInfoByParamterServiceFilter:  Id={id},Name={Name}";
        }


        [HttpGet]
        [Route("GetInfoByParamterCustomFilter")]
        [CustomIOCFilterFactoryPara(typeof(CustomActionFilterLogLogAttribute))]// register with services
        public string GetInfoByParamterCustomFilter(int id, string Name)
        {
            return $"this is GetInfoByParamterCustomFilter:  Id={id},Name={Name}";
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
