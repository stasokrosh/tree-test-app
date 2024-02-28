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
                throw new SecureException("Parent was not found");
            }

            if (parent.Children.Any(x => x.Name == name))
            {
                throw new SecureException(
                    "There is already a sibling with this name");
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
                throw new SecureException("Node was not found");
            }

            if (node.Children.Any())
            {
                throw new SecureException(
                    "Node children should be deleted first");
            }

            await _repository.RemoveAsync(node);
        }

        public async Task RenameAsync(long nodeId, string name)
        {
            var node = await _repository
                .FindNodeWithSiblingsAsync(nodeId);

            if (node == null)
            {
                throw new SecureException("Node was not found");
            }

            if (node.Parent != null && node.Parent.Children
                .Any(x => x.Name == name && x.Id != nodeId))
            {
                throw new SecureException(
                    "There is already a sibling with this name");
            }

            node.Name = name;

            await _repository.UpdateAsync(node);
        }
    }
}
