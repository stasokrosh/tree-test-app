using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using TreeApp.Services;

namespace TreeApp.Web.Controllers
{
    [ApiController]
    public class TreeNodeController
    {
        private readonly ITreeNodeService _service;

        public TreeNodeController(
            ITreeNodeService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("/api.user.tree.node.create")]
        public async Task Create([Required] long parentId, [Required] string name)
        {
            await _service.CreateAsync(parentId, name);
        }

        [HttpPost]
        [Route("/api.user.tree.get.delete")]
        public async Task Delete([Required] long nodeId)
        {
            await _service.DeleteAsync(nodeId);
        }

        [HttpPost]
        [Route("/api.user.tree.get.rename")]
        public async Task Rename([Required] long nodeId, [Required] string name)
        {
            await _service.RenameAsync(nodeId, name);
        }
    }
}
