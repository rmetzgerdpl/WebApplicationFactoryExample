using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplicationFactoryEx.ConsoleApp.DTO;
using WebApplicationFactoryEx.ConsoleApp.Managers;

namespace WebApplicationFactoryEx.ConsoleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private IWeatherManager _manager;
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IWeatherManager manager)
        {
            _logger = logger;
            _manager = manager;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return _manager.GetWeatherReport(5);
        }
    }
}