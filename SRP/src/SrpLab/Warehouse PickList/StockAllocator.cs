using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class StockAllocator
    {
        public IReadOnlyList<(string Sku, int Allocated)> Allocate(IEnumerable<PickLine> lines)
        {
            return lines
                .Select(l => (l.Sku, Allocated: Math.Min(l.QtyNeeded, l.QtyOnHand)))
                .ToList();
        }
    }
}
