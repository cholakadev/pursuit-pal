using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Services;

namespace PursuitPal.Presentation.Api.Controllers
{
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }


        [HttpPost(nameof(Register))]
        public async Task<IActionResult> Register([FromBody] CreateUpdateUserRequest request)
            => Ok(await _usersService.RegisterUserAsync(request));

        [HttpPost(nameof(Login))]
        public async Task<IActionResult> Login([FromBody] GenerateUserTokenRequest request)
            => Ok(await _usersService.GenerateUserTokenAsync(request));
    }
}
