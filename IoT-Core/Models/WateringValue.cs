using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class WateringValue
    {
        public int Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        public ObjectId SensorsId { get; set; }

        public int Milliseconds { get; set; }


        public WateringValue()
        {
            Date = DateTime.Now;
        }

        public WateringValue(SensorValues sensors, int milliseconds)
            : this()
        {
            SensorsId = sensors.Id;
            Milliseconds = milliseconds;
        }
    }
}
