using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoT_Core.Services.Repositories;

namespace IoT_Core.Controllers
{
    [Route("api/[controller]")]
    public class WateringController : Controller
    {
        private IWateringRepository _wateringRepository;

        public WateringController(IWateringRepository wateringRepository)
        {
            _wateringRepository = wateringRepository;
        }

        // GET api/watering
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _wateringRepository.GetWateringsAsync();
            return Ok(results);
        }

        // GET api/watering/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var watering = await _wateringRepository.GetWateringByIdAsync(id);
            if (watering == null)
            {
                return NotFound();
            }

            return Ok(watering);
        }
    }
}