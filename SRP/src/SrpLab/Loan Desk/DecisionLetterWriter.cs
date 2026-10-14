using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class DecisionLetterWriter
    {
        public string Write(
            string applicantName,
            LoanApplication application,
            decimal riskScore,
            bool isEligible,
            IReadOnlyList<string> requiredDocuments)
        {
            if (isEligible)
            {
                return $"Dear {applicantName},\n" +
                       $"Your request for {application.RequestedAmount:C} is pre-approved (risk {riskScore:0}).\n" +
                       $"Please upload: {string.Join("; ", requiredDocuments)}.\n";
            }

            return $"Dear {applicantName},\n" +
                   $"We are unable to approve {application.RequestedAmount:C} at this time.\n" +
                   $"Reference risk={riskScore:0}. You may reapply after improving documentation.\n";
        }
    }
}
