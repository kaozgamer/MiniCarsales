using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniCarsales.Models;
using MiniCarsales.Services;

namespace MiniCarsales.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        readonly IVehicleService _vehicleService;
        readonly ILogger<VehicleController> _logger;

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="vehicleService">The vehicle service.</param>
        /// <param name="logger">The logger for this controller.</param>
        public VehicleController(IVehicleService vehicleService, ILogger<VehicleController> logger)
        {
            _vehicleService = vehicleService;
            _logger = logger;
        }

        /// <summary>
        /// Gets all the people stored in memory.
        /// </summary>
        /// <returns>All people stored in memory.</returns>
        [HttpGet]
        public IEnumerable<Vehicle> Get()
        {
            var vehicles = _vehicleService.GetAll();
            _logger.LogInformation($"Retrieving all vehicles (count: {vehicles.Count})");
            return _vehicleService.GetAll();
        }

        [HttpPost]
        public void Post([FromBody] Vehicle vehicle)
        {
            _logger.LogInformation($"Saving vehicle {vehicle}");
            _vehicleService.SaveOrUpdate(vehicle);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _logger.LogInformation($"Deleting vehicle wiht id {id}");
            _vehicleService.Delete(id);
        }
    }
}
