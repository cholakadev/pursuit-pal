using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Services.Factories
{
    public static class GoalFactory
    {
        public static Goal ToEntity(this CreateUpdateGoalRequest request, Guid userId)
            => new Goal
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

        public static CreateUpdateGoalResponse ToResponse(this Goal entity)
            => new CreateUpdateGoalResponse
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
