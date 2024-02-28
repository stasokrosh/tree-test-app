using AutoMapper;
using TreeApp.DB;
using TreeApp.DB.Entities;
using TreeApp.Services.DTO;

namespace TreeApp.Services
{
    internal class TreeService : ITreeService
    {
        private ITreeNodeRepository _repository;
        private IMapper _mapper;

        public TreeService(
            ITreeNodeRepository repository, 
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<TreeNodeDTO> GetOrCreateAsync(string name)
        {
            var root = await _repository.FindRootAsync(name);

            if (root == null)
            {
                root = new TreeNode
                {
                    Name = name
                };

                root.Id = await _repository.CreateAsync(root);
            }
            else
            {
                var nodeDictionary = root.RootChildren
                    .ToDictionary(x => x.Id);
                nodeDictionary[root.Id] = root;

                TreeNode parentNode = null;

                foreach (var node in root.RootChildren
                    .OrderBy(x => x.ParentId)) 
                {
                    if (parentNode == null || parentNode.Id != node.ParentId)
                    {
                        parentNode = nodeDictionary[node.ParentId.Value];
                        parentNode.RootChildren = new List<TreeNode>();
                    }

                    parentNode.Children.Add(node);
                }
            }

            return _mapper.Map<TreeNodeDTO>(root);
        }
    }
}
