using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public sealed class InvoiceNumberGenerator
    {
        private static int _sequence = 1000;

        public string Next(DateOnly periodStart)
        {
            int number = ++_sequence;
            return $"INV-{periodStart:yyyyMM}-{number:D5}";
        }
    }
}
