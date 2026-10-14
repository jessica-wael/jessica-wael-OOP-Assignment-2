using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.LoanDesk
{
    public sealed record LoanApplication(
    decimal RequestedAmount,
    int CreditScore,
    int EmploymentMonths,
    bool HasCollateral);
}
