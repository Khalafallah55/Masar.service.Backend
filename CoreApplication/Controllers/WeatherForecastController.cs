using Mcs.Masar.Documentum;
using Mcs.Masar.Jics;
using Mcs.Masar.workflow;
using Microsoft.AspNetCore.Mvc;

namespace CoreApplication.Controllers
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

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            var Documtentum = new Documentum();
            var workFlow = new Workflow();
            var Jisc = new Jics();
            
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Documtentum.DocmentmDummyValue + workFlow.WorkflowDummyValue + Jisc.DocmentmJicsValue
            })
            .ToArray();
        }
    }
}
