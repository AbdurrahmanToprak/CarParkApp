using CarPark.Core.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.DataAccess.Context
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;
        public MongoDBContext(IOptions<MongoSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.Database);
        }
        public IMongoCollection<TEntity> GetMongoCollection<TEntity>()
        {
            return _database.GetCollection<TEntity>(typeof(TEntity).Name.Trim());
        }
        public IMongoDatabase GetDatabase() { return _database; }
    }
}
