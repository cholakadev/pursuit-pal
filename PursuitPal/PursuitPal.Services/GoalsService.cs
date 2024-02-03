using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    public class GoalsService : IGoalsService
    {
        private readonly IRepository<Goal> _goalsRepository;
        private readonly IUsersContextService _usersContextService;

        public GoalsService(
            IRepository<Goal> goalsRepository,
            IUsersContextService usersContextService)
        {
            _goalsRepository = goalsRepository ?? throw new ArgumentNullException(nameof(goalsRepository));
            _usersContextService = usersContextService ?? throw new ArgumentNullException(nameof(usersContextService));
        }
        public async Task<CreateUpdateGoalResponse> CreateGoalAsync(CreateUpdateGoalRequest request)
        {
            var goalToCreate = request.ToEntity(_usersContextService.UserId);
            var createdGoal = await _goalsRepository.AddAsync(goalToCreate);

            if (createdGoal is null)
            {
                throw new FailedCreationException(nameof(CreateGoalAsync));
            }

            return createdGoal.ToResponse();
        }

        public async Task<IEnumerable<GoalResponse>> GetAllGoalsAsync(GetGoalsRequest request)
        {
            var userId = _usersContextService.UserId;
            var goalStatuses = request.Statuses.Select(x => x.ToStringStatus());

            return await _goalsRepository.GetAll()
                .Include(x => x.Details)
                .Where(x => x.UserId == userId &&
                            (!request.Statuses.Any() || goalStatuses.Contains(x.Status)) &&
                            x.FromDate >= request.FromDate && x.ToDate <= request.ToDate)
                .Select(x => x.ToGoalResponse())
                .ToListAsync();
        }
    }
}
