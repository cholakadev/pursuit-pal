﻿using PursuitPal.Core.Helpers;

namespace PursuitPal.Core.Requests
{
    public class GetGoalsRequest
    {
        public IEnumerable<GoalStatus> Statuses { get; set; } = Enum.GetValues(typeof(GoalStatus)).Cast<GoalStatus>().ToList();

        public DateTime FromDate { get; set; } = DateTime.UtcNow;

        public DateTime ToDate { get; set; } = DateTime.UtcNow.AddMonths(12);

        // TODO: Add order by filters
    }
}
