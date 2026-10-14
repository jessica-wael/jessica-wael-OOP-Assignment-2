using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed class AllergenDetector
    {
        private static readonly (string Allergen, string[] Keywords)[] Rules =
        {
        ("dairy", new[] { "milk", "cheese", "butter" }),
        ("gluten", new[] { "wheat", "flour", "bread" }),
        ("nuts", new[] { "peanut", "almond", "cashew" }),
        ("shellfish", new[] { "shrimp", "prawn", "crab" }),
    };

        public IReadOnlyList<string> Detect(IEnumerable<TicketItem> items)
        {
            var hits = new SortedSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var item in items)
            {
                foreach (var ingredient in item.Ingredients)
                {
                    foreach (var (allergen, keywords) in Rules)
                    {
                        if (keywords.Any(k => ingredient.Contains(k)))
                            hits.Add(allergen);
                    }
                }
            }

            return hits.ToList();
        }

    }
}
