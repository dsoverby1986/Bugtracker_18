using Bugtracker.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Bugtracker.Models
{
    public class TicketHistory
    {
        private ApplicationDbContext db;

        public TicketHistory(Ticket ticket, Ticket oldTicket, PropertyInfo info, string userId)
        {
            TicketId = ticket.Id;
            Property = info.Name;
            DisplayProperty = ModelHelpers.GetDisplayName(ticket.GetType(), info, false);
            OldValue = oldTicket.GetType().GetProperty(info.Name).GetValue(oldTicket).ToString();
            NewValue = ticket.GetType().GetProperty(info.Name).GetValue(ticket).ToString();
            Date = DateTimeOffset.Now;
            UserId = userId;
        }

        [Key]
        public int Id { get; set; }
        public int TicketId { get; set; }
        [Required]
        public string Property { get; set; }
        [Required]
        public string DisplayProperty { get; set; }
        public string OldValue { get; set; }
        [Required]
        public string NewValue { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy hh:mm tt}")]
        public DateTimeOffset Date { get; set; }
        [Required]
        public string UserId { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}