namespace PursuitPal.Core.Requests
{
    public class AssignUserRoleRequest
    {
        public int RoleId { get; set; }

        public IEnumerable<Guid> UserIds { get; set; }
    }
}
