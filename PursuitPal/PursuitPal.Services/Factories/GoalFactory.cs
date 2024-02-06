using PursuitPal.Core.Helpers;
using PursuitPal.Core.Requests;
using PursuitPal.Core.Responses;
using PursuitPal.Infrastructure.Entities;

namespace PursuitPal.Services.Factories
{
    public static class GoalFactory
    {
        public static Goal ToEntity(this CreateGoalRequest request, Guid userId)
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

        public static Goal HavingFromDate(this Goal goal, DateTime? date)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            if (date.HasValue)
            {
                goal.FromDate = date.Value;
            }

            return goal;
        }

        public static Goal HavingToDate(this Goal goal, DateTime? date)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            if (date.HasValue)
            {
                goal.ToDate = date.Value;
            }

            return goal;
        }

        public static Goal HavingStatus(this Goal goal, GoalStatus? status)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            if (status.HasValue)
            {
                goal.Status = status.Value.ToStringStatus();
            }

            return goal;
        }

        public static Goal HavingName(this Goal goal, string? name)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            if (!string.IsNullOrEmpty(name))
            {
                goal.Details.Name = name;
            }

            return goal;
        }

        public static Goal HavingDescription(this Goal goal, string? description)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            if (!string.IsNullOrEmpty(description))
            {
                goal.Details.Description = description;
            }

            return goal;
        }

        public static Goal HavingCompletionCriteria(this Goal goal, string? completionCriteria)
        {
            if (goal == null)
                throw new ArgumentNullException(nameof(goal));

            if (!string.IsNullOrEmpty(completionCriteria))
            {
                goal.Details.CompletionCriteria = completionCriteria;
            }

            return goal;
        }

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
