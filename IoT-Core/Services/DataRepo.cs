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
        private int _listLimit;

        public DataRepo(IOptions<AppSettings> optionsAccessor)
        {
            AppSettings appSettings = optionsAccessor.Value;

            _client = new MongoClient(appSettings.MongoDbConnection);
            _database = _client.GetDatabase(appSettings.MongoDbDatabaseName);

            _listLimit = appSettings.ListLimit;
        }

        public async Task<SensorValues> AddValuesAsync(SensorValues sensors)
        {
            var sensorsCollection = _database.GetCollection<SensorValues>("sensors");
            await sensorsCollection.InsertOneAsync(sensors);
            return sensors;
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
                .Limit(_listLimit)
                .ToListAsync();
        }

        public async Task<WateringValue> AddWateringAsync(WateringValue watering)
        {
            var wateringCollection = _database.GetCollection<WateringValue>("watering");
            await wateringCollection.InsertOneAsync(watering);
            return watering;
        }

        public async Task<IEnumerable<WateringValue>> GetWaterings()
        {
            var wateringCollection = _database.GetCollection<WateringValue>("watering");
            return await wateringCollection.Find(new BsonDocument())
                .Limit(_listLimit)
                .ToListAsync();
        }
    }
}
