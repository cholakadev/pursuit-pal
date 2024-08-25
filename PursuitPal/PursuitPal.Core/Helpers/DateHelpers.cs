namespace PursuitPal.Core.Helpers
{
    public static class DateHelpers
    {
        public static DateTime GetQuarterEndDate(this DateTime dateWithinTheQuarter)
        {
            int quarterNumber = (dateWithinTheQuarter.Month - 1) / 3 + 1;
            int endMonth = quarterNumber * 3; // Last month of the quarter
            DateTime firstDayOfEndMonth = new DateTime(dateWithinTheQuarter.Year, endMonth, 1);
            var currentQuarterEndDate = firstDayOfEndMonth.AddMonths(1).AddDays(-1);

            return currentQuarterEndDate;
        }
    }
}
