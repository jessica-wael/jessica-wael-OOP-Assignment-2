using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.WarehousePickList
{
    public sealed class WmsXmlWriter
    {
        public string Write(string batchId, IEnumerable<(string Sku, int Allocated)> allocations)
        {
            var lines = allocations.Select(a => $"<line sku=\"{a.Sku}\" qty=\"{a.Allocated}\" />");
            return $"<batch id=\"{batchId}\">{string.Join("", lines)}</batch>";
        }
    }
}
