using Bugtracker.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bugtracker.Helpers
{
    public static class UserHelpers
    {
        public static string GetDisplayName(string userId)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            return db.Users.Find(userId).DisplayName;
        }
    }
}