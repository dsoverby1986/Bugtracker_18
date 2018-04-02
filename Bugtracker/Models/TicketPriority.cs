using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bugtracker.Models
{
    public class TicketPriority
    {
        public TicketPriority()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public static class TicketPriorities
    {
        public const string Highest = nameof(Highest);
        public const string High = nameof(High);
        public const string Low = nameof(Low);
        public const string Lowest = nameof(Lowest);

        public static string[] All => new string[] { Highest, High, Low, Lowest };
    }
}