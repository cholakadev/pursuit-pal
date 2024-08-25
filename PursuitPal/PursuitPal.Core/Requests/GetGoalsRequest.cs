using PursuitPal.Core.Enums;

namespace PursuitPal.Core.Requests
{
    public class GetGoalsRequest
    {
        public IEnumerable<GoalStatus> Statuses { get; set; }

        public DateTime? FromDate { get; set; }

        public DateTime? ToDate { get; set; }

        public Guid? UserId { get; set; }

        // TODO: Add order by filters
    }
}
