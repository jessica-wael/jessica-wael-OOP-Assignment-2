using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class HandoffNoteWriter
    {
        public string Write(int bed, string? patientId, int acuity, string tone)
        {
            if (patientId is null) return $"Bed {bed}: empty";

            return $"[HANDOFF {DateTime.UtcNow:yyyy-MM-dd}] Bed {bed} · {patientId} · acuity={acuity} · {tone}";
        }
    }
}
