using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Services;

namespace PursuitPal.Presentation.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class GoalsController : Controller
    {
        private readonly IUsersContextService _contextService;

        public GoalsController(IUsersContextService contextService)
        {
            _contextService = contextService ?? throw new ArgumentNullException(nameof(contextService));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateGoal([FromBody] object goal)
        {
            var id = _contextService.UserId;
            throw new NotImplementedException();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoal([FromBody] object goal)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoalById([FromQuery] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            throw new NotImplementedException();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteGoal([FromQuery] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
