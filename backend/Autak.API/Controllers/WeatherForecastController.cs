using System.Collections.Generic;
using Autak.API.FakeDB;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Autak.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        private readonly IDatabase database;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDatabase database)
        {
            _logger = logger;
            this.database = database;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            return database.GetWeatherForecasts();
        }
    }
}