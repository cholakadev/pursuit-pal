namespace PursuitPal.Core.Helpers
{
    public static class EnumToStringConverter
    {
        public static string ToStringStatus(this GoalStatus status)
        {
            return StatusToStringMap.TryGetValue(status, out var value) ? value : status.ToString();
        }

        private static readonly Dictionary<GoalStatus, string> StatusToStringMap = new Dictionary<GoalStatus, string>
        {
            { GoalStatus.Active, "Active" },
            { GoalStatus.InProgress, "In Progress" },
            { GoalStatus.Completed, "Completed" },
        };
    }
}
