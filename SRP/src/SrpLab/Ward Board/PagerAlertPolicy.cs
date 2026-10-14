using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class PagerAlertPolicy
    {  
        private const int EscalateThreshold = 8;
        private const int WatchThreshold = 4;

        public bool ShouldAlert(int acuityScore) => acuityScore >= EscalateThreshold;

        public string ToneFor(int acuityScore) =>
            acuityScore >= EscalateThreshold ? "ESCALATE"
            : acuityScore >= WatchThreshold ? "WATCH"
            : "STABLE";
    }
}
