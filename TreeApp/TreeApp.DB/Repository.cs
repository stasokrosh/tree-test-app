using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using TreeApp.DB.Context;
using TreeApp.DB.Entities;

namespace TreeApp.DB
{
    internal abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly DbSet<TEntity> _dbSet;
        private readonly TreeAppDBContext _dbContext;

        public Repository(TreeAppDBContext context)
        {
            _dbSet = context.Set<TEntity>();
            _dbContext = context;
        }

        protected DbSet<TEntity> DbSet { get {  return _dbSet; } }

        public async Task<long> CreateAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<TEntity> FindByIdAsync(long id)
        {
            return await DbSet.FirstOrDefaultAsync(
                x => x.Id == id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(
            Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.Where(filter).ToListAsync();
        }

        public async Task RemoveAsync(TEntity entity)
        {
            DbSet.Remove(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
