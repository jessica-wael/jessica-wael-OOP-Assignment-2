using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public sealed class PublicReplyWriter
    {
        public string Write(string ticketId, string priority, string agentName, DateTimeOffset deadline)
        {
            string opening = priority == "P1"
                ? "We are treating this as a critical incident."
                : "Thanks for reaching out.";

            return $"Hi,\n{opening}\nTicket {ticketId} is with {agentName}. Next update before {deadline:u}.\n";
        }
    }
}
