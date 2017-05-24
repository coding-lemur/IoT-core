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
        private DataContext _dataContext;
        private IWateringService _wateringService;

        public ValuesController(DataContext dataContext, IWateringService wateringService)
        {
            _dataContext = dataContext;
            _wateringService = wateringService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var results = _dataContext.Sensors
                .OrderBy(sv => sv.Id)
                .ToList();
            return Ok(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sensorValues = _dataContext.Sensors
                .FirstOrDefault(value => value.Id == id);

            if (sensorValues == null)
            {
                return NotFound();
            }

            return Ok(sensorValues);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SensorValue sensors)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // save sensor values
            _dataContext.Sensors.Add(sensors);

            var wateringResult = _wateringService.CalculateMilliseconds(sensors);

            await _dataContext.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = sensors.Id }, wateringResult);
        }
    }
}
