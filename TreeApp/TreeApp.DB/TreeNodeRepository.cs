using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using TreeApp.DB.Context;
using TreeApp.DB.Entities;

namespace TreeApp.DB
{
    internal class TreeNodeRepository : Repository<TreeNode>, ITreeNodeRepository
    {
        public TreeNodeRepository(TreeAppDBContext context) : base(context)
        {
        }

        public async Task<TreeNode> FindNodeWithChildrenAsync(long id)
        {
            return await DbSet.Where(x =>
                x.Id == id)
                .Include(x => x.Children)
                .FirstOrDefaultAsync();
        }

        public async Task<TreeNode> FindNodeWithSiblingsAsync(long id)
        {
            return await DbSet.Where(x =>
                x.Id == id)
                .Include(x => x.Parent)
                .ThenInclude(x => x.Children)
                .FirstOrDefaultAsync();
        }

        public async Task<TreeNode> FindRootAsync(string name)
        {
            return await DbSet.Where(x => 
                x.Name == name && !x.ParentId.HasValue)
                .Include(x => x.RootChildren)
                .FirstOrDefaultAsync();
        }
    }
}
