using System.Collections.Generic;
using Autak.API.FakeDB;
using Autak.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Autak.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarAdministrationController : ControllerBase
    {
        private readonly ILogger<CarAdministrationController> logger;

        private readonly IDatabase database;

        public CarAdministrationController(ILogger<CarAdministrationController> logger, IDatabase database)
        {
            this.logger = logger;
            this.database = database;
        }


        [HttpGet]
        public IEnumerable<CarAdministrator> Get()
        {
            return database.GetCarAdministrators();
        }
    }
}