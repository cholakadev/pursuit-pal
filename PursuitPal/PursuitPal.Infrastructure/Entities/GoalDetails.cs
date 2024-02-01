namespace PursuitPal.Infrastructure.Entities
{
    public class GoalDetails : Auditable
    {
        public Guid Id { get; set; }

        public Guid GoalId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CompletionCriteria { get; set; }
    }
}
