namespace PursuitPal.Infrastructure.Entities
{
    public class Role : Auditable, IActivatable
    {
        public int Id { get; set; }

        public string RoleName { get; set; }

        public bool Active { get; set; }
    }
}
