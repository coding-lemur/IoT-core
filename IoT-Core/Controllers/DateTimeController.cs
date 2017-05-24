using IoT_Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Controllers
{
    [Route("api/[controller]")]
    public class DateTimeController
    {
        [HttpGet]
        public RtcDateTime Get()
        {
            return new RtcDateTime(DateTime.Now);
        }
    }
}
