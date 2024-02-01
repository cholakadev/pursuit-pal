using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class UsersController : Controller
    {

        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] CreateUpdateUserRequest request)
        {
            throw new NotImplementedException();
        }

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] object userData)
        {
            throw new NotImplementedException();
        }
    }
}
