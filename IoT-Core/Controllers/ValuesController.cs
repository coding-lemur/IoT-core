using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoT_Core.Models;
using IoT_Core.Services;

namespace IoT_Core.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private IDataRepo _dataRepo;
        private IWateringService _wateringService;

        public ValuesController(IDataRepo dataRepo, IWateringService wateringService)
        {
            _dataRepo = dataRepo;
            _wateringService = wateringService;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _dataRepo.GetValuesAsync();
            return Ok(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var sensorValues = await _dataRepo.GetValueByIdAsync(id);
            if (sensorValues == null)
            {
                return NotFound();
            }

            return Ok(sensorValues);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SensorsInput sensorsInput)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var sensors = new SensorValues()
            {
                //DeviceTimestamp = sensorsInput.DeviceTimestamp, // TODO change to DateTime
                Temperature = sensorsInput.Temperature.Value,
                Humidity = sensorsInput.Humidity.Value,
                SoilMoisture = sensorsInput.SoilMoisture.Value
            };

            // save sensor values
            await _dataRepo.AddValuesAsync(sensors);

            var wateringResult = _wateringService.CalculateMilliseconds(sensors);

            if (wateringResult.Milliseconds > 0)
            {
                var watering = new WateringValue(sensors, wateringResult.Milliseconds);
                _dataRepo.AddWateringAsync(watering);
            }

            return CreatedAtAction("Get", new { id = sensors.Id }, wateringResult);
        }
    }
}
