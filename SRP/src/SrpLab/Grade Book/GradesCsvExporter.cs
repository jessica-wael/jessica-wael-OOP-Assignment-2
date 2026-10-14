using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class GradesCsvExporter
    {
        public string Export(IEnumerable<(string Id, decimal Average, string Letter, bool Honor)> rows)
        {
            var lines = new List<string> { "studentId,average,letter,honor" };
            lines.AddRange(rows.Select(r => $"{r.Id},{r.Average},{r.Letter},{(r.Honor ? 1 : 0)}"));
            return string.Join('\n', lines);
        }
    }
}
