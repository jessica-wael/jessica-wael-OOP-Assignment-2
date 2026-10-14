using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class PickerScriptWriter
    {
        public string Write(
            IReadOnlyList<(string Aisle, int Bin, string Sku, int Qty)> walkingOrder,
            IEnumerable<PickLine> lines)
        {
            var steps = walkingOrder.Select((s, i) =>
                $"{i + 1}. Go aisle {s.Aisle} bin {s.Bin}: pick {s.Qty} × {s.Sku}");

            var shortages = lines
                .Where(l => l.QtyOnHand < l.QtyNeeded)
                .Select(l => l.Sku)
                .ToList();

            string warning = shortages.Count > 0
                ? "SHORTAGES: " + string.Join(", ", shortages)
                : "SHORTAGES: none";

            return string.Join('\n', steps) + "\n" + warning;
        }
    }
}
