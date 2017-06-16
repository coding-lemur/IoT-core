using IoT_Core.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace IoT_Core.Services.Repositories
{
    public class WateringRepository : BaseRepository, IWateringRepository
    {
        public WateringRepository(IOptions<AppSettings> optionsAccessor) 
            : base(optionsAccessor)
        {
        }

        public async Task<WateringValue> AddWateringAsync(WateringValue watering)
        {
            var wateringCollection = _database.GetCollection<WateringValue>("watering");
            await wateringCollection.InsertOneAsync(watering);
            return watering;
        }

        public async Task<WateringValue> GetWateringByIdAsync(string id)
        {
            var wateringCollection = _database.GetCollection<WateringValue>("watering");

            var objectId = new ObjectId(id);
            var filter = Builders<WateringValue>.Filter.Eq(wv => wv.Id, objectId);

            return await wateringCollection.Find(filter)
                .FirstAsync<WateringValue>();
        }

        public async Task<IEnumerable<WateringValue>> GetWateringsAsync()
        {
            var wateringCollection = _database.GetCollection<WateringValue>("watering");
            return await wateringCollection.Find(new BsonDocument())
                .Limit(_listLimit)
                .ToListAsync();
        }
    }
}
