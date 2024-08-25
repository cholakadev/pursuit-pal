using Azure.Core;
using Microsoft.EntityFrameworkCore;
using PursuitPal.Core.Contracts.Repositories;
using PursuitPal.Core.Contracts.Services;
using PursuitPal.Core.Enums;
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
        public async Task<GoalResponse> CreateGoalAsync(CreateGoalRequest request)
        {
            var goalToCreate = request.ToEntity(_usersContextService.UserId);
            var createdGoal = await _goalsRepository.AddAsync(goalToCreate);

            if (createdGoal is null)
                throw new CreateUpdateFailedException(nameof(CreateGoalAsync));

            return createdGoal.ToResponse();
        }

        public async Task<IEnumerable<GoalResponse>> GetAllGoalsAsync(GetGoalsRequest request)
        {
            var currentQuarterEndDate = DateTime.UtcNow;
            var userIdFilter = _usersContextService.UserId;

            var currentUserRoles = _usersContextService.Roles;
            var userChildRoles = GetAllChildRolesByHierarchy(currentUserRoles!.ToList());

            if (request.UserId.HasValue && !userChildRoles.Any())
                throw new UnauthorizedAccessException();

            if (request.UserId.HasValue && userChildRoles.Any())
                userIdFilter = request.UserId!.Value;

            var query = _goalsRepository.GetAll()
                .Include(x => x.Details)
                .Where(x => x.UserId == userIdFilter &&
                            (!request.Statuses.Any() || request.Statuses.Contains(x.Status)));

            if (request is { FromDate: null, ToDate: null })
            {
                var currentDate = DateTime.UtcNow;
                currentQuarterEndDate = currentDate.GetQuarterEndDate();

                query = query.Where(x => x.ToDate <= currentQuarterEndDate);
            }
            else
            {
                query = query.Where(x => (!request.FromDate.HasValue || x.ToDate >= request.FromDate) &&
                                            (!request.ToDate.HasValue || x.ToDate <= request.ToDate));
            }

            return await query
                    .Select(x => x.ToResponse())
                    .ToListAsync();
        }

        public async Task<GoalResponse?> GetGoalByIdAsync(Guid goalId, Guid? userId)
        {
            var userIdFilter = _usersContextService.UserId;

            var currentUserRoles = _usersContextService.Roles;
            var userChildRoles = GetAllChildRolesByHierarchy(currentUserRoles!.ToList());

            if (userId.HasValue && !userChildRoles.Any())
                throw new UnauthorizedAccessException();

            if (userId.HasValue && userChildRoles.Any())
                userIdFilter = userId!.Value;

            var goal = await _goalsRepository.GetAll()
                .Include(x => x.Details)
                .FirstOrDefaultAsync(x => x.UserId == userIdFilter && x.Id == goalId);

            if (goal is null)
                throw new KeyNotFoundException();

            return goal.ToResponse();
        }

        public async Task<GoalResponse> UpdateGoalAsync(UpdateGoalRequest request)
        {
            var goal = await _goalsRepository.GetAll()
                .Include(x => x.Details)
                .FirstOrDefaultAsync(x => x.Id == request.Id && x.UserId == _usersContextService.UserId);

            if (goal is null)
                throw new KeyNotFoundException();

            var goalToUpdate = goal
                .HavingName(request.Name)
                .HavingFromDate(request.FromDate)
                .HavingToDate(request.ToDate)
                .HavingDescription(request.Description)
                .HavingCompletionCriteria(request.CompletionCriteria)
                .HavingStatus(request.Status);

            var updatedGoal = await _goalsRepository.UpdateAsync(goalToUpdate);

            if (updatedGoal is null)
                throw new CreateUpdateFailedException(nameof(UpdateGoalAsync));

            return updatedGoal.ToResponse();
        }

        private List<UserRole> GetAllChildRolesByHierarchy(List<UserRole> roles)
        {
            var childRoles = new List<UserRole>();

            foreach (var role in roles)
            {
                var childRolesPerRole = role switch
                {
                    UserRole.Employee => new List<UserRole>(),
                    UserRole.Lead => new List<UserRole> { UserRole.Employee },
                    UserRole.Manager => new List<UserRole> { UserRole.Employee, UserRole.Lead },
                    UserRole.Admin => new List<UserRole> { UserRole.Employee, UserRole.Lead, UserRole.Manager },
                    UserRole.SystemAdmin => new List<UserRole> { UserRole.Employee, UserRole.Lead, UserRole.Manager, UserRole.Admin },
                    _ => new List<UserRole> { UserRole.Employee } // Default case if none above match
                };

                childRoles.AddRange(childRolesPerRole);
            }

            return childRoles;
        }
    }
}
