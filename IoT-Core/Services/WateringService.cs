using IoT_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services
{
    public class WateringService: IWateringService
    {
        private IDataRepo _dataRepo;

        public WateringService(IDataRepo dataRepo)
        {
            _dataRepo = dataRepo;
        }

        public WateringResult CalculateMilliseconds(SensorValues sensors)
        {
            int milliseconds = 0;

            if (sensors.SoilMoisture < 600)
            {
                // watering
                milliseconds = 3000;

                var watering = new WateringValue()
                {
                    Milliseconds = milliseconds,
                    Sensors = sensors
                };
                //_dataContext.Watering.Add(watering);
            }

            var wateringResult = new WateringResult()
            {
                Milliseconds = milliseconds
            };
            return wateringResult;
        }
    }
}
