using IoT_Core.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IoT_Core.Services.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly MongoClient _client;
        protected readonly IMongoDatabase _database;

        protected readonly int _listLimit;

        public BaseRepository(IOptions<AppSettings> optionsAccessor)
        {
            AppSettings appSettings = optionsAccessor.Value;

            _client = new MongoClient(appSettings.MongoDbConnection);
            _database = _client.GetDatabase(appSettings.MongoDbDatabaseName);

            _listLimit = appSettings.ListLimit;
        }
    }
}
