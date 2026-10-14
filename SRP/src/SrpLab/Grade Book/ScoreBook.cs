using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab
{
    public sealed class ScoreBook
    {
        private readonly Dictionary<string, List<decimal>> _scores = new(StringComparer.OrdinalIgnoreCase);

        public void Record(string studentId, decimal score)
        {
            if (score is < 0 or > 100) throw new ArgumentOutOfRangeException(nameof(score));
            if (!_scores.TryGetValue(studentId, out var list))
                _scores[studentId] = list = new List<decimal>();
            list.Add(score);
        }

        public IReadOnlyList<decimal> ScoresOf(string studentId) =>
            _scores.TryGetValue(studentId, out var list) ? list : new List<decimal>();

        public IEnumerable<string> StudentIds() => _scores.Keys.OrderBy(x => x);
    }

}
