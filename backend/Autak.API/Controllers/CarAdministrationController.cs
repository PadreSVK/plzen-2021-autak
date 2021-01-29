using Autak.API.FakeDB;
using Autak.API.FakeDB.Filters;
using Autak.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace Autak.API.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CarAdministrationController : ControllerBase
	{
		private readonly IDatabase database;
		private readonly ILogger<CarAdministrationController> logger;

		public CarAdministrationController(ILogger<CarAdministrationController> logger, IDatabase database)
		{
			this.logger = logger;
			this.database = database;
		}


		[HttpGet]
		//https: //localhost:5001/api/CarAdministration?page=1&itemsPerPage=10&sortBy[]=name&sortDesc[]=false&mustSort=false&multiSort=false
		public CarAdministratorDataTableModel Get([FromQuery] int page, [FromQuery] int itemsPerPage,
			[FromQuery(Name = "sortBy[]")] List<string> sortBy, [FromQuery(Name = "sortDesc[]")] List<bool> sortDesc)
		{
			var carAdministratorFilter = new CarAdministratorFilter
			{
				ItemsPerPage = itemsPerPage,
				Page = page,
				SortFilters = sortBy.Select((s, i) => new SortFilter {By = s, Descending = sortDesc[i]})
			};

			logger.LogInformation($"{nameof(sortBy)} {string.Concat(sortBy)}");
			logger.LogInformation($"{nameof(sortDesc)} {string.Concat(sortDesc)}");
			return database.GetCarAdministrators(carAdministratorFilter);
		}

		[HttpGet("cars")]
		//https: //localhost:5001/api/CarAdministration?page=1&itemsPerPage=10&sortBy[]=name&sortDesc[]=false&mustSort=false&multiSort=false
		public CarDataTableModel GetCars([FromQuery] int page, [FromQuery] int itemsPerPage,
			[FromQuery(Name = "sortBy[]")] List<string> sortBy, [FromQuery(Name = "sortDesc[]")] List<bool> sortDesc)
		{
			var carFilter = new CarFilter()
			{
				ItemsPerPage = itemsPerPage,
				Page = page,
				SortFilters = sortBy.Select((s, i) => new SortFilter { By = s, Descending = sortDesc[i] })
			};

			logger.LogInformation($"{nameof(sortBy)} {string.Concat(sortBy)}");
			logger.LogInformation($"{nameof(sortDesc)} {string.Concat(sortDesc)}");
			return database.GetCars(carFilter);
		}
	}
}