using System;
using System.Collections.Generic;
using Autak.API.Models;
using Bogus;

namespace Autak.API.FakeDB
{
    public class FakeDatabase : IDatabase
    {
        private readonly IEnumerable<CarAdministrator> carAdministrators;
        private readonly IEnumerable<WeatherForecast> weatherForecasts;

        public FakeDatabase()
        {
            Randomizer.Seed = new Random(6519835);
            weatherForecasts = CreateWeatherForecasts();
            carAdministrators = CreateCarAdministrators();
        }


        public IEnumerable<WeatherForecast> GetWeatherForecasts()
        {
            return weatherForecasts;
        }

        public IEnumerable<CarAdministrator> GetCarAdministrators()
        {
            return carAdministrators;
        }

        private static IEnumerable<WeatherForecast> CreateWeatherForecasts(int count = 20)
        {
            string[] summaries =
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };


            var weatherFaker = new Faker<WeatherForecast>()
                .RuleFor(o => o.Date, f => f.Date.Past())
                .RuleFor(o => o.TemperatureC, f => f.Random.Int(-40, 50))
                .RuleFor(o => o.Summary, f => f.PickRandom(summaries));
            return weatherFaker.Generate(count);
        }

        private static IEnumerable<CarAdministrator> CreateCarAdministrators(int count = 20)
        {
            var weatherFaker = new Faker<CarAdministrator>("cz")
                .RuleFor(o => o.Name, f => f.Person.FullName)
                .RuleFor(o => o.Note, f => f.Rant.Review())
                .RuleFor(o => o.Role, f => f.PickRandom<CarAdministratorRole>())
                ;
            return weatherFaker.Generate(count);
        }
    }
}