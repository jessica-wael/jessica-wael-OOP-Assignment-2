using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SubscriptionBilling
{
    public sealed class PaymentFailureTracker
    {
        public int Failures { get; private set; }

        public void Register() => Failures++;
    }
}
