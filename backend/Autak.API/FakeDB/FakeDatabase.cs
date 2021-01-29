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
		private readonly IEnumerable<Car> cars;
		private readonly IEnumerable<WeatherForecast> weatherForecasts;

		public FakeDatabase()
		{
			Randomizer.Seed = new Random(6519835);
			weatherForecasts = CreateWeatherForecasts();
			carAdministrators = CreateCarAdministrators(200);
			cars = CreateCars(carAdministrators, 200);
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


		public CarDataTableModel GetCars(CarFilter filter)
		{
			var resultQuery = cars;
			foreach (var sortFilter in filter.SortFilters)
			{
				resultQuery = sortFilter.By switch
				{
					"name" => sortFilter.Descending
						? resultQuery.OrderByDescending(i => i.Name)
						: resultQuery.OrderBy(i => i.Name),
					"spz" => sortFilter.Descending
						? resultQuery.OrderByDescending(i => i.Spz)
						: resultQuery.OrderBy(i => i.Spz),
					"type" => sortFilter.Descending
						? resultQuery.OrderByDescending(i => i.Type)
						: resultQuery.OrderBy(i => i.Spz),
					_ => throw new ArgumentOutOfRangeException()
				};
			}

			var itemsToSkip = (filter.Page - 1) * filter.ItemsPerPage;
			resultQuery = resultQuery.Skip(itemsToSkip).Take(filter.ItemsPerPage);

			return new CarDataTableModel
			{
				Items = resultQuery,
				ElementsMetadata =
					new[]
					{
						new FormElementMetadata
						{
							Type = "FormText", Key = "name", Label = "Nazev", ValidationRules = "alpha"
						},
						new FormElementMetadata
						{
							Type = "FormText", Key = "type", Label = "Typ", ValidationRules = "alpha"
						},
						new FormElementMetadata {Type = "FormText", Key = "spz", Label = "Spz"},
						new FormElementMetadata {Type = "FormDate", Key = "dateTime", Label = "Datum"}
					},
				TotalItems = cars.Count(),
				Headers = new[]
				{
					new CarDataTableHeader
					{
						Value = nameof(Car.Name).ToLower(), Text = "Nazev", Sortable = true, Type = "TableText"
					},
					new CarDataTableHeader
					{
						Value = nameof(Car.Spz).ToLower(), Text = "Spz", Sortable = true, Type = "TableText"
					},
					new CarDataTableHeader
					{
						Value = nameof(Car.Type).ToLower(),
						Text = "Typ",
						Sortable = true,
						Type = "TableText"
					},
					new CarDataTableHeader
					{
						Value = "dateTime", Text = "Datum", Sortable = true, Type = "TableDate"
					},
					new CarDataTableHeader
					{
						Value = $"{nameof(Car.Administrator)}.{nameof(CarAdministrator.Name)}".ToLower(),
						Text = "Spravce",
						Sortable = true,
						Type = "TableText"
					}
				}
			};
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


		private static IEnumerable<Car> CreateCars(IEnumerable<CarAdministrator> administrators, int count = 20)
		{
			var weatherFaker = new Faker<Car>("cz")
					.RuleFor(o => o.Name, f => f.Company.CompanyName())
					.RuleFor(o => o.Spz, f => f.Internet.Ip())
					.RuleFor(o => o.Type, f => f.Commerce.ProductName())
					.RuleFor(o => o.Administrator, f => f.PickRandom(administrators))
					.RuleFor(o => o.DateTime, f => f.Date.Future())
				;
			return weatherFaker.Generate(count);
		}
	}
}