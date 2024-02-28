using AutoMapper;
using TreeApp.DB.Entities;

namespace TreeApp.Services.DTO.Mapping
{
    public class JournalProfile : Profile
    {
        public JournalProfile() 
        {
            CreateMap<JournalRecord, JournalRecordDTO>();
            CreateMap<JournalRecord, JournalListItemDTO>();
        }
    }
}
