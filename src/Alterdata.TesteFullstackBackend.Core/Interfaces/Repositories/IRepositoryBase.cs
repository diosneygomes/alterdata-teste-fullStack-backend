namespace Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity>
    {
        Task<bool> IsExistsAsync(int id);

        Task<TEntity> GetByIdAsync(int id);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task CreateAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(int id);
    }
}
