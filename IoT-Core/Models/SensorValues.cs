using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Models
{
    public class SensorValues
    {
        public ObjectId Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime Date { get; set; }

        //public int? DeviceTimestamp { get; set; }

        public float Temperature { get; set; }

        public float Humidity { get; set; }

        public int SoilMoisture { get; set; }


        public SensorValues()
        {
            Date = DateTime.Now;
        }
    }
}
