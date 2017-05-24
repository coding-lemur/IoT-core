using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class SensorValue
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        public DateTime DeviceDate { get; set; }

        [Required]
        public float? Temperature { get; set; }

        [Required]
        public float? Humidity { get; set; }

        [Required]
        public int? SoilMoisture { get; set; }
    }
}
