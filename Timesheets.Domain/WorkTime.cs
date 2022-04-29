﻿namespace Timesheets.Domain
{
    public record WorkTime
    {
        public const int MIN_WORKING_HOURS_PER_DAY = 1;
        public const int MAX_WORKING_HOURS_PER_DAY = 24;

        private WorkTime(int projectId, int hours, DateTime date)
        {
            ProjectId = projectId;
            Hours = hours;
            Date = date;
        }

        public int ProjectId { get; }

        public int Hours { get; }

        public DateTime Date { get;  }

        public static (WorkTime? Result, string[] Errors) Create(int projectId, int hours, DateTime date)
        {
            if (projectId < MIN_WORKING_HOURS_PER_DAY)
            {
                return (null, new string[] { "Id cannot be less then 1." });
            }

            if (hours < MIN_WORKING_HOURS_PER_DAY || hours > MAX_WORKING_HOURS_PER_DAY)
            {
                return (null, new string[] { "Hours should be between 0 and 24." });
            }

            if (date > DateTime.Now)
            {
                return (null, new string[] { "You cannot select a future date." });
            }

            return (
                new WorkTime(projectId, hours, date),
                Array.Empty<string>());
        }
    }
}