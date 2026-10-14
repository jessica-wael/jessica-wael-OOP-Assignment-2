using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class UnderwriterCsvExporter
    {
        public string Row(string applicationId, LoanApplication application, decimal riskScore, bool isEligible)
        {
            var collateral = application.HasCollateral ? 1 : 0;
            var eligible = isEligible ? "Y" : "N";

            return $"{applicationId},{application.CreditScore},{application.EmploymentMonths},{collateral},{riskScore:0.00},{eligible}";
        }
    }
}
