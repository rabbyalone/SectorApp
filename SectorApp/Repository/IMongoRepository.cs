namespace SectorApp.Repository
{
    public interface IMongoRepository<TDocument>
    {
        Task<IEnumerable<TDocument>> GetAllAsync();
        Task<TDocument> InsertAsync(TDocument entity);
        Task<TDocument> UpdateAsync(Guid id, TDocument entity);
        Task DeleteAsync(TDocument entity);
    }
}
