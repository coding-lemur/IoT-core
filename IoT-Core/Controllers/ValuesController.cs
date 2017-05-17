using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoT_Core.Models;

namespace IoT_Core.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private SensorValueContext _dbContext;

        public ValuesController(SensorValueContext dbContext)
        {
            this._dbContext = dbContext;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var results = _dbContext.SensorValues
                .OrderBy(sv => sv.Id)
                .ToList();
            return Ok(results);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var sensorValues = _dbContext.SensorValues
                .FirstOrDefault(value => value.Id == id);

            if (sensorValues == null)
            {
                return NotFound();
            }

            return Ok(sensorValues);
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]SensorValues values)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _dbContext.SensorValues.Add(values);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction("Get", values.Id);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]string value)
        {
            return Forbid();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Forbid();
        }
    }
}
