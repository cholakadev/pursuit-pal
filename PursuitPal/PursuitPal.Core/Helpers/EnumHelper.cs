using PursuitPal.Core.Enums;
using System.Runtime.Serialization;

namespace PursuitPal.Core.Helpers
{
    public static class EnumHelper
    {
        public static string ToStringStatus(this GoalStatus status)
            => StatusToStringMap.TryGetValue(status, out var value) ? value : status.ToString();

        private static readonly Dictionary<GoalStatus, string> StatusToStringMap = new Dictionary<GoalStatus, string>
        {
            { GoalStatus.Active, "Active" },
            { GoalStatus.InProgress, "In Progress" },
            { GoalStatus.Completed, "Completed" },
        };
    }
}
