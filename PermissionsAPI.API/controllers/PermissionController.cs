using Microsoft.AspNetCore.Mvc;
using PermissionsAPI.Domain.Entities;
using MediatR;
using PermissionsAPI.Application.Permissions.Commands;

namespace PermissionsAPI.API.Controllers
{
    [ApiController]
    [Route("api/permissions")]
    public class PermissionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public PermissionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var permissions = new List<Permission>();
            return Ok(permissions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var permission = new Permission();
            if (permission == null) return NotFound();
            return Ok(permission);
        }

        [HttpPost]
        public async Task<IActionResult> RequestPermission([FromBody] RequestPermissionCommand command)
        {
            var id = await _mediator.Send(command);
            return CreatedAtAction(nameof(RequestPermission), new { id }, id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ModifyPermission(int id, [FromBody] Permission permission)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var updatedPermission = new Permission();
            if (updatedPermission == null) return NotFound();

            return Ok(updatedPermission);
        }
    }
}