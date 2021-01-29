using System;
using System.Collections.Generic;
using Autak.API.Models;
using Bogus;

namespace Autak.API.FakeDB
{
    public class FakeDatabase : IDatabase
    {
        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            var count = 20;
            string[] summaries =
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };

            Randomizer.Seed = new Random(6519835);
            var weatherFaker = new Faker<WeatherForecast>()
                .RuleFor(o => o.Date, f => f.Date.Past())
                .RuleFor(o => o.TemperatureC, f => f.Random.Int(-40, 50))
                .RuleFor(o => o.Summary, f => f.PickRandom(summaries));

            return weatherFaker.Generate(count);
        }
    }
}