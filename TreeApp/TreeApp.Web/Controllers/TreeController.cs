using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TreeApp.Services;
using TreeApp.Services.DTO;

namespace TreeApp.Web.Controllers
{
    [ApiController]
    [Route("/api.user.tree.get")]
    public class TreeController
    {
        private readonly ITreeService _service;

        public TreeController(
            ITreeService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<TreeNodeDTO> Get([Required] string name)
        {
            return await _service.GetOrCreateAsync(name);
        }
    }
}
