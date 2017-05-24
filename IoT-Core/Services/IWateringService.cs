using IoT_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services
{
    public interface IWateringService
    {
        WateringResult CalculateMilliseconds(SensorValue sensors);
    }
}
