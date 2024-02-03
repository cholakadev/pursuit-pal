﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Requests;

namespace PursuitPal.Presentation.Api.Controllers
{
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ApiController, ApiVersion("1.0"), Route("api/v{version:apiVersion}/[controller]")]
    public class GoalsController : Controller
    {
        private readonly IGoalsService _goalsService;

        public GoalsController(IGoalsService goalsService)
        {
            _goalsService = goalsService ?? throw new ArgumentNullException(nameof(goalsService));
        }

        [HttpPost, Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> CreateGoal([FromBody] CreateUpdateGoalRequest request)
            => CreatedAtAction(nameof(CreateGoal), await _goalsService.CreateGoalAsync(request));

        [HttpPut, Authorize]
        public async Task<IActionResult> UpdateGoal([FromBody] object goal)
        {
            throw new NotImplementedException();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGoalById([FromQuery] Guid id)
        {
            throw new NotImplementedException();
        }

        [HttpGet, Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllGoals([FromQuery] GetGoalsRequest request)
        {
            var result = await _goalsService.GetAllGoalsAsync(request);

            if (result != null && result.Any())
            {
                return Ok(result);
            }

            return NoContent();
        }

        [HttpDelete, Authorize]
        public async Task<IActionResult> DeleteGoal([FromQuery] Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
