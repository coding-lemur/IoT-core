using IoT_Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services.Repositories
{
    public interface IWateringRepository
    {
        Task<WateringValue> AddWateringAsync(WateringValue watering);
        Task<WateringValue> GetWateringByIdAsync(string id);
        Task<IEnumerable<WateringValue>> GetWateringsAsync();
    }
}
