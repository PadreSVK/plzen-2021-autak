using System.Collections.Generic;
using Autak.API.Models;

namespace Autak.API.FakeDB
{
    public interface IDatabase
    {
        IEnumerable<WeatherForecast> GetWeatherForecasts();
        IEnumerable<CarAdministrator> GetCarAdministrators();
    }
}