using TreeApp.Services.DTO;

namespace TreeApp.Services
{
    public interface ITreeService
    {
        Task<TreeNodeDTO> GetOrCreateAsync(string name);
    }
}
