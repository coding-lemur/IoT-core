using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using IoT_Core.Services;

namespace IoT_Core.Controllers
{
    [Route("api/[controller]")]
    public class WateringController : Controller
    {
        private IDataRepo _dataRepo;

        public WateringController(IDataRepo dataRepo)
        {
            _dataRepo = dataRepo;
        }

        // GET api/watering
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = await _dataRepo.GetWaterings();
            return Ok(results);
        }
    }
}