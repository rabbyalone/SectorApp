using MongoDB.Driver;

namespace SectorApp.Repository
{
    public interface IMongoRepository<TDocument>
    {
        Task<IEnumerable<TDocument>> GetAllAsync(FilterDefinition<TDocument> filter);
        Task<TDocument> InsertAsync(TDocument entity);
        Task<TDocument> GetByIdAsync(object id);
        Task<TDocument> UpdateAsync(object id, TDocument entity);
        Task DeleteAsync(TDocument entity);
    }
}
