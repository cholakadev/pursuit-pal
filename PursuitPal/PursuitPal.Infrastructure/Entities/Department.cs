namespace PursuitPal.Infrastructure.Entities
{
    public class Department : Auditable, IActivatable
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? NameShort { get; set; }

        public bool Active { get; set; }

        public IEnumerable<User> Users { get; set; }
    }
}
