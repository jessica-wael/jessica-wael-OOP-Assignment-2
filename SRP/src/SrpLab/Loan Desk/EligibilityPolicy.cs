using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class EligibilityPolicy
    {
        private const decimal MinimumRiskScore = 55m;
        private const int MinimumCreditScore = 580;

        public bool IsEligible(LoanApplication application, decimal riskScore) =>
            riskScore >= MinimumRiskScore && application.CreditScore >= MinimumCreditScore;
    }
}
