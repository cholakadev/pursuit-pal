namespace PursuitPal.Core.Requests
{
    public class ManageDirectReportsRequest
    {
        public Guid? ReportsToUserId { get; set; }

        public IEnumerable<Guid> UserIds { get; set; }

    }
}
