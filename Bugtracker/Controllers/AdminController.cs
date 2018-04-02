using Bugtracker.Infrastructure;
using Bugtracker.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Bugtracker.Controllers
{
    [Authorize(Roles = AppRoles.Admin)]
    public class AdminController : Controller
    {
        ApplicationDbContext _db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult ManageUsers()
        {
            AdminUsersViewModel model = new AdminUsersViewModel()
            {
                Users = _db.Users.Include(u =>  u.Projects).Include(u => u.Tickets).Include(u => u.Roles).ToList(),
                RolesDictionary = _db.Roles.ToDictionary(k => k.Id, v => v.Name)
            };

            return View(model);
        }
    }
}