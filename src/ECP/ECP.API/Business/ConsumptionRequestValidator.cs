namespace ECP.API.Business
{
    using System;

    public class ConsumptionRequestValidator
    {
        public static bool Validate(DateTime startDate, DateTime endDate, string grouping)
        {
            if (startDate < DateTime.Today.AddYears(-2))
                return false;

            if (startDate > endDate)
                return false;

            if (!grouping.Equals("day") && !grouping.Equals("week") && !grouping.Equals("month"))
                return false;

            if (endDate > DateTime.Today)
                return false;

            return true;
        }
    }
}
