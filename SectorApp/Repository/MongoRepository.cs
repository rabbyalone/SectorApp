using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SectorApp.Config;

namespace SectorApp.Repository
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private readonly IMongoCollection<T> _collection;

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            var filter = Builders<T>.Filter.Exists("_id");
            return await _collection.Find(filter).ToListAsync();
        }

        private object GetId(T entity)
        {
            var property = typeof(T).GetProperty("Id");
            if (property == null)
                throw new ArgumentException("The entity must have a property named 'Id'.");

            return property.GetValue(entity);
        }

        public MongoRepository(IOptions<DbSettings> dbSettings)
        {
            var client = new MongoClient(dbSettings.Value.MongoConnection);
            var database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = database.GetCollection<T>(dbSettings.Value.CollectionName);
        }

        public async Task<T> InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(int id, T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            await _collection.ReplaceOneAsync(filter, entity);
            return entity;
        }

        public async Task DeleteAsync(T entity)
        {
            var filter = Builders<T>.Filter.Eq("_id", GetId(entity));
            await _collection.DeleteOneAsync(filter);
        }
    }
}
