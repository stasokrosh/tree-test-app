using TreeApp.DB.Entities;

namespace TreeApp.DB
{
    public interface IJournalRecordRepository : IRepository<JournalRecord>
    {
        Task<int> GetCountAsync();

        Task<IEnumerable<JournalRecord>> GetListAsync(
            int skip,
            int count,
            DateTime? from,
            DateTime? to,
            string searchItem);
    }
}
