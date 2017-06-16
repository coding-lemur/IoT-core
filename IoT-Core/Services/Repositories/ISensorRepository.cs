using IoT_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services.Repositories
{
    public interface ISensorRepository
    {
        Task<SensorValues> AddSensorValuesAsync(SensorValues sensors);
        Task<SensorValues> GetSensorValuesByIdAsync(string id);
        Task<IEnumerable<SensorValues>> GetSensorValuesAsync();
    }
}
