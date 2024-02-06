using PursuitPal.Core.Helpers;

namespace PursuitPal.Core.Requests
{
    public class UpdateGoalRequest
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public string? CompletionCriteria { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public GoalStatus? Status { get; set; }
    }
}
