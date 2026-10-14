using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class PagerLog
    {
        private readonly List<string> _entries = new();

        public void Add(int bed) =>
            _entries.Add($"CODE-YELLOW bed={bed} at {DateTime.UtcNow:HH:mm}");

        public IReadOnlyList<string> Drain()
        {
            var copy = _entries.ToList();
            _entries.Clear();
            return copy;
        }
    }
}
