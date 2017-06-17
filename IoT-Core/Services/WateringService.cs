using IoT_Core.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services
{
    public class WateringService: IWateringService
    {
        private readonly AppSettings _appSettings;

        public WateringService(IOptions<AppSettings> optionsAccessor)
        {
            _appSettings = optionsAccessor.Value;
        }

        public WateringResult CalculateMilliseconds(SensorValues sensors)
        {
            var wateringResult = new WateringResult();

            if (sensors.SoilMoisture >= _appSettings.MinSoilMoisture)
            {
                // watering
                wateringResult.Milliseconds = _appSettings.WateringMilliseconds;
            }

            return wateringResult;
        }
    }
}
