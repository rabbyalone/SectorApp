namespace SectorApp.Repository
{
    public interface IMongoRepository<TDocument>
    {
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<TDocument> InsertAsync(TDocument entity);
        Task<TDocument> GetByIdAsync(object id);
        Task<TDocument> UpdateAsync(object id, TDocument entity);
        Task DeleteAsync(TDocument entity);
    }
}
