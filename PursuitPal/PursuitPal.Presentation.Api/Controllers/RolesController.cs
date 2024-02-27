using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Controllers
{
    [Authorize(Roles = "Admin,SystemAdmin")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class RolesController : Controller
    {
        private readonly IRolesService _rolesService;
        public RolesController(IRolesService rolesService)
        {
            _rolesService = rolesService ?? throw new ArgumentNullException(nameof(rolesService));
        }

        [HttpPost]
        public async Task<IActionResult> CreateRole(object request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetRoles()
            => Ok(await _rolesService.GetAllRolesAsync());

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] AssignUserRoleRequest request)
            => Ok(await _rolesService.AssignUserRoleAsync(request));
    }
}
