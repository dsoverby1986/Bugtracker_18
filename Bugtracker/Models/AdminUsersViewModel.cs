using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bugtracker.Models
{
    public class AdminUsersViewModel
    {
        public IEnumerable<ApplicationUser> Users { get; set; }
        public Dictionary<string, string> RolesDictionary { get; set; }
    }
}