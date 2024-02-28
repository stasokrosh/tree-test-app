using TreeApp.DB;
using TreeApp.DB.Entities;

namespace TreeApp.Services
{
    internal class TreeNodeService : ITreeNodeService
    {
        private ITreeNodeRepository _repository;

        public TreeNodeService(
            ITreeNodeRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateAsync(long parentId, string name)
        {
            var parent = await _repository
                .FindNodeWithChildrenAsync(parentId);

            if (parent == null)
            {
                throw new Exception();
            }

            if (parent.Children.Any(x => x.Name == name))
            {
                throw new Exception();
            }

            await _repository.CreateAsync(
                new TreeNode
                {
                    Name = name,
                    ParentId = parentId,
                    RootId = parent.RootId ?? parentId
                });
        }

        public async Task DeleteAsync(long nodeId)
        {
            var node = await _repository
                .FindNodeWithChildrenAsync(nodeId);

            if (node == null)
            {
                throw new Exception();
            }

            if (node.Children.Any())
            {
                throw new Exception();
            }

            await _repository.RemoveAsync(node);
        }

        public async Task RenameAsync(long nodeId, string name)
        {
            var node = await _repository
                .FindNodeWithSiblingsAsync(nodeId);

            if (node == null)
            {
                throw new Exception();
            }

            if (node.Parent != null && node.Parent.Children
                .Any(x => x.Name == name && x.Id != nodeId))
            {
                throw new Exception();
            }

            node.Name = name;

            await _repository.UpdateAsync(node);
        }
    }
}
