using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public sealed class ProrationCalculator
    {
        public decimal Prorate(decimal monthlyPrice, BillingPeriod period, DateOnly activeFrom)
        {
            if (activeFrom <= period.Start)
                return monthlyPrice;

            if (activeFrom >= period.End)
                return 0m;

            int totalDays = period.End.DayNumber - period.Start.DayNumber;
            if (totalDays <= 0)
                return monthlyPrice;

            int usedDays = period.End.DayNumber - activeFrom.DayNumber;
            return Math.Round(monthlyPrice * usedDays / totalDays, 2);
        }
    }
}
