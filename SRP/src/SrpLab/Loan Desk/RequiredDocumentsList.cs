using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed class RequiredDocumentsList
    {
        public IReadOnlyList<string> For(LoanApplication application, bool isEligible)
        {
            var docs = new List<string> { "National ID", "Proof of income (3 months)" };

            if (application.RequestedAmount > 40_000m)
                docs.Add("Bank statements (6 months)");

            if (application.HasCollateral)
                docs.Add("Collateral ownership deed");

            if (application.EmploymentMonths < 12)
                docs.Add("Employer letter");

            if (!isEligible)
                docs.Add("Manual underwriter referral form");

            return docs;
        }
    }
}
