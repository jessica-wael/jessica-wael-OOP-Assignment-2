using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class AverageCalculator
    {
        public decimal Calculate(IReadOnlyList<decimal> scores) =>
       scores.Count == 0 ? 0m : Math.Round(scores.Average(), 2);
    }
}
