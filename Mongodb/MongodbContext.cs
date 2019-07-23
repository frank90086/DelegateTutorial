using delegateTutorial.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace delegateTutorial
{
    public class MongodbContext
    {
        private const string _connectionString = "mongodb://localhost:27017";
        private const string _dbName = "Delegate";
        private const string _collectionName = "MultiInsert";
        private readonly MongoClient _client;
        private readonly IMongoDatabase _db;
        private readonly IMongoCollection<User> _collection;
        public MongodbContext()
        {
            _client = new MongoClient(_connectionString);
            _db = _client.GetDatabase(_dbName);
            _collection = _db.GetCollection<User>(_collectionName);
        }

        public void Insert()
        {
            _collection.InsertOne(new User(){Name = "Frank", Id = 1});
        }
    }
}