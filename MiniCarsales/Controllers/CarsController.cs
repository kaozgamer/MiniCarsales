using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.Models;
using MiniCarsales.Services;

namespace MiniCarsales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        readonly IVehicleService _vehicleService;
        readonly ILogger<CarsController> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vehicleService">The vehicle service.</param>
        /// <param name="logger">The logger for this controller.</param>
        public CarsController(IVehicleService vehicleService, ILogger<CarsController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all the people stored in memory.
        /// </summary>
        /// <returns>All people stored in memory.</returns>
        [HttpGet]
        public IEnumerable<Car> Get()
        {
            var cars = _vehicleService.GetAll(VehicleType.Car);

            _logger.LogInformation($"Retrieving all cars (count: {cars.Count})");

            return cars.Select(vehicle => vehicle as Car);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Car vehicle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _logger.LogInformation($"Saving vehicle {vehicle}");
            _vehicleService.SaveOrUpdate(vehicle);

            return Ok(vehicle);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _logger.LogInformation($"Deleting vehicle with id {id}");
            _vehicleService.Delete(id);

            return Ok();
        }
    }
}
