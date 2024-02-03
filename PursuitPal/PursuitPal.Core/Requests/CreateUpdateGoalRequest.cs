using PursuitPal.Core.Contracts;
using PursuitPal.Core.Helpers;

namespace PursuitPal.Core.Requests
{
    public class CreateUpdateGoalRequest : IRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CompletionCriteria { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public GoalStatus Status { get; set; }
    }
}
