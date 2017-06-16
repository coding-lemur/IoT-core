using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IoT_Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace IoT_Core.Services.Repositories
{
    public class SensorRepository : BaseRepository, ISensorRepository
    {
        public SensorRepository(IOptions<AppSettings> optionsAccessor) 
            : base(optionsAccessor)
        {
        }

        public async Task<SensorValues> AddSensorValuesAsync(SensorValues sensors)
        {
            var sensorsCollection = _database.GetCollection<SensorValues>("sensors");
            await sensorsCollection.InsertOneAsync(sensors);
            return sensors;
        }

        public async Task<SensorValues> GetSensorValuesByIdAsync(String id)
        {
            var sensorsCollection = _database.GetCollection<SensorValues>("sensors");

            var objectId = new ObjectId(id);
            var filter = Builders<SensorValues>.Filter.Eq(sv => sv.Id, objectId);

            return await sensorsCollection.Find(filter)
                .FirstAsync<SensorValues>();
        }

        public async Task<IEnumerable<SensorValues>> GetSensorValuesAsync()
        {
            var sensorsCollection = _database.GetCollection<SensorValues>("sensors");
            return await sensorsCollection.Find(new BsonDocument())
                .Limit(_listLimit)
                .ToListAsync();
        }
    }
}
