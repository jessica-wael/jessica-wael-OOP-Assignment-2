using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public sealed class DunningEmailWriter
    {
        public string Write(string customerName, decimal amountDue, DateOnly asOf, int failures, string invoiceNumber)
        {
            string severity = failures switch
            {
                <= 1 => "friendly reminder",
                2 => "second notice",
                _ => "final notice before suspension",
            };

            return $"Subject: {severity} {invoiceNumber}\n" +
                   $"Hi {customerName},\n" +
                   $"Balance {amountDue:C} as of {asOf:o} ({failures} failures).\n";
        }
    }
}
