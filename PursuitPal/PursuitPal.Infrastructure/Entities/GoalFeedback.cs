namespace PursuitPal.Infrastructure.Entities
{
    public class GoalFeedback : Auditable
    {
        public Guid Id { get; set; }

        public Guid GoalId { get; set; }

        public string Feedback { get; set; }

        public Goal Goal { get; set; }
    }
}
