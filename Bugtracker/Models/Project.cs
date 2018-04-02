using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Bugtracker.Models
{
    public class Project
    {
        public Project()
        {
            this.Tickets = new HashSet<Ticket>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
        [Display(Name = "Project Manager")]
        public string ProjectManagerId { get; set; }
        
        public virtual ApplicationUser ProjectManager { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}