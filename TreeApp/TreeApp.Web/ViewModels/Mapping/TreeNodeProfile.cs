using AutoMapper;
using TreeApp.Services.DTO;

namespace TreeApp.Web.ViewModels.Mapping
{
    internal class TreeNodeProfile : Profile
    {
        public TreeNodeProfile()
        {
            CreateMap<TreeNodeDTO, TreeNodeVM>();
        }
    }
}
