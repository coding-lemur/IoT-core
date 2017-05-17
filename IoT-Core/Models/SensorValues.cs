using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class SensorValues
    {
        [Key]
        public int Id { get; set; }

        public DateTime Created { get; set; }

        [Required]
        public DateTime DeviceTime { get; set; }

        [Required]
        public int? Temperature { get; set; }

        [Required]
        public byte? Humidity { get; set; }

        [Required]
        public int? SoilMoisture { get; set; }
    }
}
