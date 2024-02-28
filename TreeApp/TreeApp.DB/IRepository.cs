using System.Linq.Expressions;

namespace TreeApp.DB
{
    public interface IRepository<TEntity>
    {
        Task<long> CreateAsync(TEntity entity);

        Task RemoveAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task<TEntity> FindByIdAsync(long id);

        Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter);
    }
}
