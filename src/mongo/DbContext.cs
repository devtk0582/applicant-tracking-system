using ATS.Persistence.Abstractions;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;

namespace ATS.Persistence.Mongo
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _db;

        public DbContext(string connectionString)
        {
            var mongoUrl = new MongoUrlBuilder(connectionString);
            var client = new MongoClient(mongoUrl.ToMongoUrl());
            _db = client.GetDatabase(mongoUrl.DatabaseName);
        }

        public DbContext(string server, string database)
        {
            var client = new MongoClient(server);
            _db = client.GetDatabase(database);
        }

        public IMongoCollection<T> GetCollection<T>() => _db.GetCollection<T>(typeof(T).Name);
        public IMongoCollection<BsonDocument> GetCollection(string name) => _db.GetCollection<BsonDocument>(name);

        public void RegisterClassMap<T>()
        {
            if (BsonClassMap.IsClassMapRegistered(typeof(T)))
                return;

            BsonClassMap.RegisterClassMap<T>(x =>
            {
                x.AutoMap();
                x.SetIgnoreExtraElements(true);
            });
        }
    }
}
