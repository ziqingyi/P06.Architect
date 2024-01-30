using Microsoft.AspNetCore.Mvc;
using P09.IOC_Container_DI_Using_Attribute.Interfaces;
using P09.IOC_Container_DI_Using_Attribute.Models;
using P09.IOC_Container_DI_Using_Attribute.Services;

namespace P09.IOC_Container_DI_Using_Attribute.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private IAuthService _service;
        public WeatherForecastController(IAuthService service,ILogger<WeatherForecastController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var res= Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

            //load service using ServiceLoader, without registering
            var svc = ServiceLoader.Instance.GetService<IAuthServiceNew>();
            var newRes = svc.CheckToken();

            if (_service.CheckToken())
            {
                return res;
            }
            return Enumerable.Empty<WeatherForecast>();
            
        }
    }
}
