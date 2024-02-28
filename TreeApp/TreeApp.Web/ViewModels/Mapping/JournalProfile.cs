using AutoMapper;
using TreeApp.Services.DTO;

namespace TreeApp.Web.ViewModels.Mapping
{
    public class JournalProfile : Profile
    {
        public JournalProfile()
        {
            CreateMap<JournalRecordDTO, JournalRecordVM>();
            CreateMap<JournalListDTO, JournalListVM>();
            CreateMap<JournalListItemDTO, JournalListItemVM>();
        }
    }
}
