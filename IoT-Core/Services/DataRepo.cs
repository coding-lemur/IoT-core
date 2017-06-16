using IoT_Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services
{
    public class DataRepo: IDataRepo
    {
        private MongoClient _client;
        private IMongoDatabase _database;

        public DataRepo(IOptions<AppSettings> optionsAccessor)
        {
            AppSettings appSettings = optionsAccessor.Value;

            _client = new MongoClient(appSettings.MongoDbConnection);
            _database = _client.GetDatabase(appSettings.MongoDbDatabaseName);
        }

        public async Task<SensorValues> AddValuesAsync(SensorValues sensorValues)
        {
            var sensorsCollection = _database.GetCollection<SensorValues>("sensors");
            await sensorsCollection.InsertOneAsync(sensorValues);

            return sensorValues;
        }

        public async Task<SensorValues> GetValueByIdAsync(String id)
        {
            var sensorsCollection = _database.GetCollection<SensorValues>("sensors");

            var objectId = new ObjectId(id);
            var filter = Builders<SensorValues>.Filter.Eq(sv => sv.Id, objectId);

            return await sensorsCollection.Find(filter)
                .FirstAsync<SensorValues>();
        }

        public async Task<IEnumerable<SensorValues>> GetValuesAsync()
        {
            var sensorsCollection = _database.GetCollection<SensorValues>("sensors");
            return await sensorsCollection.Find(new BsonDocument())
                .Limit(100)
                .ToListAsync();
        }
    }
}
