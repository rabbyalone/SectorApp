namespace SectorApp.Repository
{
    public interface IMongoRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> InsertAsync(T entity);
        Task<T> UpdateAsync(int id, T entity);
        Task DeleteAsync(T entity);
    }
}
