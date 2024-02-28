namespace TreeApp.Services
{
    public interface ITreeNodeService
    {
        Task CreateAsync(long parentId, string name);
        Task DeleteAsync(long nodeId);
        Task RenameAsync(long nodeId, string name);
    }
}
