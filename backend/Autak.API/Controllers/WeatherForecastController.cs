using Autak.API.FakeDB;
using Autak.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace Autak.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
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