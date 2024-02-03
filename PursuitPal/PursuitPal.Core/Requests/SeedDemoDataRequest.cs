using PursuitPal.Core.Contracts;

namespace PursuitPal.Core.Requests
{
    public class SeedDemoDataRequest : IRequest
    {
        public int NumberOfUsers { get; set; }

        public int NumberOfGoalsPerUser { get; set; }
    }
}
