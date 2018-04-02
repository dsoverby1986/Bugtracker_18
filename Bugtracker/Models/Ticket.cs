using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bugtracker.Models
{
    public class Ticket
    {
        public Ticket()
        {
            this.TicketComments = new HashSet<TicketComment>();
            this.TicketAttachments = new HashSet<TicketAttachment>();
            this.TicketNotifications = new HashSet<TicketNotification>();
            this.TicketHistories = new HashSet<TicketHistory>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [DisplayName("Created Date")]
        public DateTimeOffset Created { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        [DisplayName("Project")]
        public int ProjectId { get; set; }
        [Required]
        [DisplayName("Assigned User")]
        public string AssignedUserId { get; set; }
        [Required]
        [DisplayName("Ticket Priority")]
        public int TicketPriorityId { get; set; }
        [Required]
        [DisplayName("Ticket Status")]
        public int TicketStatusId { get; set; }

        public virtual Project Project { get; set; }
        public virtual ApplicationUser AssignedUser { get; set; }
        public virtual TicketStatus TicketStatus { get; set; }
        public virtual TicketPriority TicketPriority { get; set; }
        public virtual ICollection<TicketComment> TicketComments { get; set; }
        public virtual ICollection<TicketAttachment> TicketAttachments { get; set; }
        public virtual ICollection<TicketNotification> TicketNotifications { get; set; }
        public virtual ICollection<TicketHistory> TicketHistories { get; set; }
    }
}