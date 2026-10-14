using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class WalkingOrderPlanner
    {
        public IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> Plan(IEnumerable<PickLine> lines)
        {
            return lines
                .OrderBy(l => l.Aisle)
                .ThenBy(l => l.Bin)
                .Select(l => (l.Aisle, l.Bin, l.Sku, Qty: Math.Min(l.QtyNeeded, l.QtyOnHand)))
                .Where(x => x.Qty > 0)
                .ToList();
        }
    }
}
