using PursuitPal.Core.Enums;

namespace PursuitPal.Core.Requests
{
    public class GetGoalsRequest
    {
        public IEnumerable<GoalStatus> Statuses { get; set; }

        public DateTime FromDate { get; set; } = DateTime.UtcNow.AddMonths(-3);

        public DateTime ToDate { get; set; } = DateTime.UtcNow.AddMonths(3);

        // TODO: Add order by filters
    }
}
