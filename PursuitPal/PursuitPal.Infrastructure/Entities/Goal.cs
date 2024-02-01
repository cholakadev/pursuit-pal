namespace PursuitPal.Infrastructure.Entities
{
    public class Goal : Auditable
    {
        public Guid Id { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int Status { get; set; }

        public Guid UserId { get; set; }
    }
}
