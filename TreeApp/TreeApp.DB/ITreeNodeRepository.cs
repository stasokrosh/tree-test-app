using System.ComponentModel.DataAnnotations;
using TreeApp.DB.Entities;

namespace TreeApp.DB
{
    public interface ITreeNodeRepository : IRepository<TreeNode>
    {
        Task<TreeNode> FindRootAsync(string name);

        Task<TreeNode> FindNodeWithChildrenAsync(long id);

        Task<TreeNode> FindNodeWithSiblingsAsync(long id);
    }
}
