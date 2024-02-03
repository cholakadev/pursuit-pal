using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Services.Factories
{
    public static class GoalFactory
    {
        public static Goal ToEntity(this CreateUpdateGoalRequest request, Guid userId)
            => request is null
            ? throw new ArgumentNullException(nameof(request))
            : new Goal
            {
                UserId = userId,
                FromDate = request.FromDate,
                ToDate = request.ToDate,
                Status = request.Status.ToStringStatus(),
                Details = new GoalDetails
                {
                    Name = request.Name,
                    Description = request.Description,
                    CompletionCriteria = request.CompletionCriteria,
                }
            };

        public static GoalResponse ToResponse(this Goal entity)
            => entity is null
            ? throw new ArgumentNullException(nameof(entity))
            : new GoalResponse
            {
                Id = entity.Id,
                FromDate = entity.FromDate,
                ToDate = entity.ToDate,
                Status = entity.Status,
                Name = entity.Details.Name,
                Description = entity.Details.Description,
                CompletionCriteria = entity.Details.CompletionCriteria
            };
    }
}
