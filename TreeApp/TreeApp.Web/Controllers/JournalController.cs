using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TreeApp.Services;
using TreeApp.Web.ViewModels;

namespace TreeApp.Web.Controllers
{
    [ApiController]
    public class JournalController
    {
        private readonly IMapper _mapper;
        private readonly IJournalService _service;

        public JournalController(
            IMapper mapper, 
            IJournalService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpPost]
        [Route("/api.user.journal.getSingle")]
        public async Task<JournalRecordVM> GetSingle([Required] long id)
        {
            return _mapper.Map<JournalRecordVM>(
                await _service.FindAsync(id));
        }

        [HttpPost]
        [Route("/api.user.journal.getRange")]
        public async Task<JournalListVM> GetRange(
            [Required] int skip,
            [Required] int count,
            [Required][FromBody] JournalListFilter filter)
        {
            return _mapper.Map<JournalListVM>(
                await _service.GetListAsync(
                    skip,
                    count,
                    filter.From,
                    filter.To,
                    filter.Search));
        }
    }
}
