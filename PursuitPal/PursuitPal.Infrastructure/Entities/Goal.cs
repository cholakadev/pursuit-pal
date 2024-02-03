namespace PursuitPal.Infrastructure.Entities
{
    public class Goal : Auditable, IActivatable
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Status { get; set; }

        public bool Active { get; set; }

        public GoalDetails Details { get; set; }

        public User User { get; set; }

        public IEnumerable<GoalFeedback> Feedbacks { get; set; }
    }
}
