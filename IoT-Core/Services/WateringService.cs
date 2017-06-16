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
            var wateringResult = new WateringResult();

            if (sensors.SoilMoisture < 600)
            {
                // watering
                wateringResult.Milliseconds = 3000;
            }

            return wateringResult;
        }
    }
}
