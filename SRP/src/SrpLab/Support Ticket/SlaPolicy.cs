using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public sealed class SlaPolicy
    {
        public DateTimeOffset Deadline(DateTimeOffset openedAt, string priority)
        {
            int hours = priority switch
            {
                "P1" => 4,
                "P2" => 24,
                _ => 72,
            };

            return openedAt.AddHours(hours);
        }

        public bool IsBreached(DateTimeOffset deadline, DateTimeOffset now) => now > deadline;
    }
}
