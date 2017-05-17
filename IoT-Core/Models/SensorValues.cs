using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class SensorValues
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public DateTime DeviceTime { get; set; }
        public int Temperature { get; set; }
        public byte Humidity { get; set; }
        public int SoilMoisture { get; set; }
    }
}
