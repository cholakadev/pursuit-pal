using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Controllers
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService ?? throw new ArgumentNullException(nameof(usersService));
        }


        [HttpPost(nameof(Register)), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Register([FromBody] CreateUpdateUserRequest request)
            => CreatedAtAction(nameof(Register), await _usersService.RegisterUserAsync(request));

        [HttpPost(nameof(Login)), AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Login([FromBody] GenerateUserTokenRequest request)
            => Ok(await _usersService.GenerateUserTokenAsync(request));
    }
}
