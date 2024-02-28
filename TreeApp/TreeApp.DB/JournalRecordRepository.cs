using Microsoft.EntityFrameworkCore;
using TreeApp.DB.Context;
using TreeApp.DB.Entities;

namespace TreeApp.DB
{
    internal class JournalRecordRepository : Repository<JournalRecord>, 
        IJournalRecordRepository
    {
        public JournalRecordRepository(TreeAppDBContext context) : base(context)
        {
        }

        public Task<int> GetCountAsync()
        {
            return Task.FromResult(DbSet.Count());
        }

        public async Task<IEnumerable<JournalRecord>> GetListAsync(
            int skip, 
            int count, 
            DateTime? from, 
            DateTime? to, 
            string searchItem)
        {
            if (count == 0)
            {
                return new List<JournalRecord>();
            }

            var query = DbSet.AsQueryable();

            if (from.HasValue)
            {
                query = query.Where(x => x.CreatedAt >= from);
            }

            if (to.HasValue)
            {
                query = query.Where(x => x.CreatedAt <= to);
            }

            if (skip > 0)
            {
                query = query.Skip(skip);
            }

            query = query.Take(count);

            if (!String.IsNullOrEmpty(searchItem))
            {
                query = query.Where(x => x.Text.Contains(searchItem));
            }
            return await query.ToListAsync();
        }
    }
}
