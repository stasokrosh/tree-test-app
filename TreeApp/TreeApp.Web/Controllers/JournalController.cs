using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TreeApp.Services;
using TreeApp.Services.DTO;
using TreeApp.Web.ViewModels;

namespace TreeApp.Web.Controllers
{
    [ApiController]
    public class JournalController
    {
        private readonly IJournalService _service;

        public JournalController( 
            IJournalService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/api.user.journal.getSingle")]
        public async Task<JournalRecordDTO> GetSingle([Required] long id)
        {
            return await _service.FindAsync(id);
        }

        [HttpPost]
        [Route("/api.user.journal.getRange")]
        public async Task<JournalListDTO> GetRange(
            [Required] int skip,
            [Required] int count,
            [Required][FromBody] JournalListFilter filter)
        {
            return await _service.GetListAsync(
                skip,
                count,
                filter.From,
                filter.To,
                filter.Search);
        }
    }
}
