using IoT_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services
{
    public interface IDataRepo
    {
        Task<SensorValues> AddValuesAsync(SensorValues sensors);
        Task<SensorValues> GetValueByIdAsync(string id);
        Task<IEnumerable<SensorValues>> GetValuesAsync();
        Task<WateringValue> AddWateringAsync(WateringValue watering);
        Task<IEnumerable<WateringValue>> GetWaterings();
    }
}
