using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class CensusCsvExporter
    {


        public string Export(IEnumerable<(int Bed, string Patient, int Acuity)> rows)
        {
            var lines = new List<string> { "bed,patient,acuity" };
            lines.AddRange(rows.Select(r => $"{r.Bed},{r.Patient},{r.Acuity}"));
            return string.Join('\n', lines);

        }
    }
}

