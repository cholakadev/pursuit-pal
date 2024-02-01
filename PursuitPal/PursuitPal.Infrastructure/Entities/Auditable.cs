namespace PursuitPal.Infrastructure.Entities
{
    public abstract class Auditable
    {
        public DateTime CreatedAt { get; set; }

        public Guid CreatedBy { get; set; }

        public DateTime UpdatedAt { get; set; }

        public Guid UpdatedBy { get; set; }
    }
}
