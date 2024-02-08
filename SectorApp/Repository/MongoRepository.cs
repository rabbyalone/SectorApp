using Microsoft.Extensions.Options;
using MongoDB.Driver;
using SectorApp.Config;

namespace SectorApp.Repository
{
    public class MongoRepository<T> : IMongoRepository<T> where T : class
    {
        private IMongoCollection<T> _collection;
        private readonly IMongoDatabase _database;


        public MongoRepository(IOptions<DbSettings> dbSettings)
        {
            var client = new MongoClient(dbSettings.Value.MongoConnection);
            _database = client.GetDatabase(dbSettings.Value.DatabaseName);
            _collection = _database.GetCollection<T>(typeof(T).Name);
        }




        public async Task<IEnumerable<T>> GetAllAsync(FilterDefinition<T> filter)
        {

            return await _collection.Find(filter).ToListAsync();
        }

        public async Task<T> GetByIdAsync(object id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return await _collection.Find(filter).SingleOrDefaultAsync();
        }

        private object GetId(T entity)
        {
            var property = typeof(T).GetProperty("Id");
            if (property == null)
                throw new ArgumentException("The entity must have a property named 'Id'.");

            return property.GetValue(entity);
        }



        public async Task<T> InsertAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> UpdateAsync(object id, T entity)
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
