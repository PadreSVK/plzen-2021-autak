using Autak.API.FakeDB.Filters;
using Autak.API.Models;
using Bogus;
using System;
using System.Collections.Generic;
using System.Linq;

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
			carAdministrators = CreateCarAdministrators(200);
		}


		public IEnumerable<WeatherForecast> GetWeatherForecasts() => weatherForecasts;

		public CarAdministratorDataTableModel GetCarAdministrators(CarAdministratorFilter filter)
		{
			// todo additional filtering function 
			// could be passed as argument
			//Func<IEnumerable<CarAdministrator>, IEnumerable<CarAdministrator>> additionalFunc = (query) =>
			//{
			//    query = query.Where(i => i.Name != "Fero");
			//    return query;
			//};

			var resultQuery = carAdministrators;
			foreach (var sortFilter in filter.SortFilters)
			{
				resultQuery = sortFilter.By switch
				{
					"name" => sortFilter.Descending
						? resultQuery.OrderByDescending(i => i.Name)
						: resultQuery.OrderBy(i => i.Name),
					"note" => sortFilter.Descending
						? resultQuery.OrderByDescending(i => i.Note)
						: resultQuery.OrderBy(i => i.Note),
					_ => throw new ArgumentOutOfRangeException()
				};
			}
			// todo additional filtering function 
			// resultQuery = additionalFunc(resultQuery);

			var itemsToSkip = (filter.Page - 1) * filter.ItemsPerPage;
			resultQuery = resultQuery.Skip(itemsToSkip).Take(filter.ItemsPerPage);

			return new CarAdministratorDataTableModel {Items = resultQuery, TotalItems = carAdministrators.Count()};
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