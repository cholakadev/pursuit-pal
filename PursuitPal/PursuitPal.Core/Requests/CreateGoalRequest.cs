﻿using PursuitPal.Core.Enums;

namespace PursuitPal.Core.Requests
{
    public class CreateGoalRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CompletionCriteria { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public GoalStatus Status { get; set; }
    }
}
