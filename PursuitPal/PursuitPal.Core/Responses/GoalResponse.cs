using PursuitPal.Core.Contracts;

namespace PursuitPal.Core.Responses
{
    public class GoalResponse : IResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string CompletionCriteria { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public string Status { get; set; }
    }
}
