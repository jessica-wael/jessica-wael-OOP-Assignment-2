using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed class OrderTicket
    {
        private readonly List<TicketItem> _items = new();

        public IReadOnlyList<TicketItem> Items => _items;

        public void AddItem(string name, IEnumerable<string> ingredients, int prepMinutes)
        {
            var normalized = ingredients.Select(i => i.Trim().ToLowerInvariant()).ToList();
            _items.Add(new TicketItem(name, normalized, prepMinutes));
        }
    }
}
