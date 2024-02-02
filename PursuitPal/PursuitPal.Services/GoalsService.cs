using PursuitPal.Core.Exceptions.OperationExceptions;
using PursuitPal.Core.Repositories;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Core.Services;
using PursuitPal.Infrastructure.Entities;
using PursuitPal.Services.Factories;

namespace PursuitPal.Services
{
    internal class GoalsService : IGoalsService
    {
        private readonly IRepository<Goal> _goalsRepository;

        public GoalsService(IRepository<Goal> goalsRepository)
        {
            _goalsRepository = goalsRepository ?? throw new ArgumentNullException(nameof(goalsRepository));
        }
        public async Task<CreateUpdateGoalResponse> CreateGoalAsync(CreateUpdateGoalRequest request)
        {
            var goalToCreate = request.ToEntity();
            var createdGoal = await _goalsRepository.AddAsync(goalToCreate);

            if (createdGoal is null)
            {
                throw new FailedCreationException(nameof(CreateGoalAsync));
            }

            return createdGoal.ToResponse();
        }
    }
}
