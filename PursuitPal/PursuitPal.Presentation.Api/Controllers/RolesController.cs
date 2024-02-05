using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PursuitPal.Presentation.Api.Controllers
{
    [Authorize(Roles = "Admin")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class RolesController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateRole(object request)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetRoles()
        {
            throw new NotImplementedException();
        }

        [HttpPost("assign")]
        public async Task<IActionResult> AssignRole([FromBody] object request)
        {
            throw new NotImplementedException();
        }
    }
}
