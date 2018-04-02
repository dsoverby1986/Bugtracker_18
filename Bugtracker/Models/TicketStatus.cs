using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bugtracker.Models
{
    public class TicketStatus
    {
        public TicketStatus()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; }
    }

    public static class TicketStatuses
    {
        public const string Approved = nameof(Approved);
        public const string AwaitingApproval = "Awaiting Approval";
        public const string Backlog = nameof(Backlog);
        public const string Blocked = nameof(Blocked);
        public const string Cancelled = nameof(Cancelled);
        public const string Closed = nameof(Closed);
        public const string Done = nameof(Done);
        public const string InProduction = "In Production";
        public const string InProgress = "In Progress";
        public const string InReview = "In Review";
        public const string Open = nameof(Open);
        public const string Rejected = nameof(Rejected);
        public const string Reopened = nameof(Reopened);
        public const string SelectedForDevelopment = "Selected For Development";
        public const string ToDo = "To Do";
        public const string UnderReview = "Under Review";

        public static string[] All => new string[] { Approved, AwaitingApproval, Backlog, Blocked, Cancelled, Closed, Done, InProduction, InProgress, InReview, Open, Rejected, Reopened, SelectedForDevelopment, ToDo, UnderReview };
    }
}