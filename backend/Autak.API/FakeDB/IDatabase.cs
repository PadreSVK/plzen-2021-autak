using Autak.API.Controllers;
using Autak.API.FakeDB.Filters;
using Autak.API.Models;
using System.Collections.Generic;

namespace Autak.API.FakeDB
{
	public interface IDatabase
	{
		IEnumerable<WeatherForecast> GetWeatherForecasts();
		CarAdministratorDataTableModel GetCarAdministrators(CarAdministratorFilter filter);
	}
}