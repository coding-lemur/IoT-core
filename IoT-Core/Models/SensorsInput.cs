using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class SensorsInput
    {
        //public int? DeviceTimestamp { get; set; }

        [Required]
        public float? Temperature { get; set; }

        [Required]
        public float? Humidity { get; set; }

        [Required]
        public int? SoilMoisture { get; set; }
    }
}
