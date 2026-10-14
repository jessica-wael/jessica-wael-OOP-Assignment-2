using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class BedAssignments
    {
        private readonly Dictionary<int, string> _bedPatient = new();
        private readonly Dictionary<int, int> _bedAcuity = new();

        public void Assign(int bed, string patientId, int acuity)
        {
            if (bed <= 0) throw new ArgumentOutOfRangeException(nameof(bed));
            if (string.IsNullOrWhiteSpace(patientId)) throw new ArgumentException("patient required");

            _bedPatient[bed] = patientId.Trim().ToUpperInvariant();
            _bedAcuity[bed] = acuity;
        }

        public string? PatientAt(int bed) =>
            _bedPatient.TryGetValue(bed, out var patient) ? patient : null;

        public int AcuityAt(int bed) => _bedAcuity[bed];

        public IEnumerable<int> Beds => _bedPatient.Keys.OrderBy(x => x);
    }
} 
