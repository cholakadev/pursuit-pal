namespace PursuitPal.Infrastructure.Entities
{
    public class User : Auditable, IActivatable
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public bool Active { get; set; }

        public IEnumerable<Goal> Goals { get; set; }
    }
}
