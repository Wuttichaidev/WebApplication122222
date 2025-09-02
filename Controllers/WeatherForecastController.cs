using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace WebApplication122222.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            try
            {
                var name = 123; 
                "".Equals(name);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "An error occurred while getting the weather forecast.");
            }
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            { 
            Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
