using IoT_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services
{
    public class WateringService: IWateringService
    {
        private DataContext _dataContext;

        public WateringService(DataContext dataContext)
        {
            _dataContext = dataContext;
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
                _dataContext.Watering.Add(watering);
            }

            var wateringResult = new WateringResult()
            {
                Milliseconds = milliseconds
            };
            return wateringResult;
        }
    }
}
