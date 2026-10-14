using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed class ReadyTimeEstimator
    {
        private const int AllergyDelayMinutes = 3;

        public int Estimate(IReadOnlyList<TicketItem> items, bool hasAllergens, int openStations)
        {
            if (items.Count == 0)
                return 0;

            if (openStations <= 0)
                openStations = 1;

            int sequential = items.Sum(i => i.PrepMinutes);
            int parallel = (int)Math.Ceiling(sequential / (double)openStations);

            if (hasAllergens)
                parallel += AllergyDelayMinutes;

            int longest = items.Max(i => i.PrepMinutes);
            return Math.Max(parallel, longest);
        }
    }
}
