using Alterdata.TesteFullstackBackend.Core.Interfaces.Repositories;
using Alterdata.TesteFullStackBackend.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Alterdata.TesteFullStackBackend.Data.Implementations
{
    public abstract class BaseRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly DbMemoryContext _dbMemoryContext;
        protected readonly DbSet<TEntity> _dbSet;

        protected BaseRepository(DbMemoryContext dbMemoryContext)
        {
            _dbMemoryContext = dbMemoryContext;
            _dbSet = dbMemoryContext.Set<TEntity>();
        }

        public async Task<bool> IsExistsAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity is not null;
        }

        public virtual async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);

            await _dbMemoryContext.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _dbSet.Update(entity);

            await _dbMemoryContext.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);

            if (entity is null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Remove(entity);

            await _dbMemoryContext.SaveChangesAsync();
        }
    }
}
