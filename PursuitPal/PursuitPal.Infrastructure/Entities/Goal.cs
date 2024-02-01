using PursuitPal.Core.Helpers;

namespace PursuitPal.Infrastructure.Entities
{
    public class Goal : Auditable
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public GoalStatus Status { get; set; }

        public GoalDetails Details { get; set; }

        public User User { get; set; }

        public IEnumerable<GoalFeedback> Feedbacks { get; set; }
    }
}
