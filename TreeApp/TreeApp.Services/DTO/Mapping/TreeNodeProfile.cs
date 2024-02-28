using AutoMapper;
using TreeApp.DB.Entities;

namespace TreeApp.Services.DTO.Mapping
{
    internal class TreeNodeProfile : Profile
    {
        public TreeNodeProfile() 
        {
            CreateMap<TreeNode, TreeNodeDTO>();
        }
    }
}
