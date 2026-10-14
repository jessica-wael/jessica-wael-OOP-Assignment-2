using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.SupportTicket
{
    public sealed class EscalationNoteWriter
    {
        public string Write(string ticketId, string priority, DateTimeOffset deadline) =>
            $"ESCALATE {ticketId} priority={priority} breachAt={deadline:u} keywords-scanned=yes";
    }
}
