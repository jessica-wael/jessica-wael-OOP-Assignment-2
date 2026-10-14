using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrpLab.KitchenTicket
{
    public sealed record TicketItem
        (string Name, IReadOnlyList<string> Ingredients, int PrepMinutes);
}
