using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TreeApp.Services;
using TreeApp.Web.ViewModels;

namespace TreeApp.Web.Controllers
{
    [ApiController]
    [Route("/api.user.tree.get")]
    public class TreeController
    {
        private readonly ITreeService _service;
        private readonly IMapper _mapper;

        public TreeController(
            ITreeService service, 
            IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<TreeNodeVM> Get([Required] string name)
        {
            return _mapper.Map<TreeNodeVM>(
                await _service.GetOrCreateAsync(name));
        }
    }
}
