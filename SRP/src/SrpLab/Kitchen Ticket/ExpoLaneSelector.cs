using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed class ExpoLaneSelector
    {
        private const int SlowThresholdMinutes = 20;

        public string Select(bool hasAllergens, int etaMinutes)
        {
            if (hasAllergens)
                return "LANE-ALLERGY";

            return etaMinutes > SlowThresholdMinutes ? "LANE-SLOW" : "LANE-FAST";
        }
    }
}
