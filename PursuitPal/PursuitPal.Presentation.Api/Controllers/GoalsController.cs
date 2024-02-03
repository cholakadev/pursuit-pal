using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Services;

namespace PursuitPal.Presentation.Api.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public class GoalsController : Controller
    {
        private readonly IGoalsService _goalsService;

        public GoalsController(IGoalsService goalsService)
        {
            _goalsService = goalsService ?? throw new ArgumentNullException(nameof(goalsService));
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateGoal([FromBody] CreateUpdateGoalRequest request)
            => CreatedAtAction(nameof(CreateGoal), await _goalsService.CreateGoalAsync(request));

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
