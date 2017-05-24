using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class WateringValue
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public int Milliseconds { get; set; }

        public SensorValue Sensors { get; set; }
    }
}
