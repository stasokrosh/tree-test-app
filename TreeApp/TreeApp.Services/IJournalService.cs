using TreeApp.Services.DTO;

namespace TreeApp.Services
{
    public interface IJournalService
    {
        Task<JournalRecordDTO> FindAsync(long id);

        Task<JournalListDTO> GetListAsync(
            int skip,
            int count,
            DateTime? from,
            DateTime? to,
            string searchItem);
    }
}
