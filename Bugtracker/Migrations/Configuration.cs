namespace Bugtracker.Migrations
{
    using Bugtracker.Infrastructure;
    using Bugtracker.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Configuration;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Bugtracker.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Bugtracker.Models.ApplicationDbContext context)
        {
            //if (System.Diagnostics.Debugger.IsAttached == false)
            //    System.Diagnostics.Debugger.Launch();

            bool changesApplied = false;

            if (!context.Roles.Any())
            {
                RoleStore<IdentityRole> roleStore = new RoleStore<IdentityRole>(context);
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(roleStore);

                foreach (string role in AppRoles.All)
                    if (!context.Roles.Any(r => r.Name == role))
                        roleManager.Create(new IdentityRole { Name = role });

                changesApplied = true;
            }

            if (!context.Users.Any())
            {
                UserStore<ApplicationUser> userStore = new UserStore<ApplicationUser>(context);
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(userStore);
                PasswordHasher passwordHasher = new PasswordHasher();
                ApplicationUser[] users = new ApplicationUser[] {
                    new ApplicationUser
                    {
                        Email = "dsoverby1986@gmail.com",
                        FirstName = "Shane",
                        LastName = "Overby",
                        DisplayName = "Shane Overby",
                        UserName = "dsoverby1986@gmail.com",
                        PasswordHash = passwordHasher.HashPassword(ConfigurationManager.AppSettings["InitAdminInitPassword"])
                    },
                    new ApplicationUser
                    {
                        Email = "DemoDev@bugtracker.com",
                        FirstName = "Demo",
                        LastName = "Developer",
                        DisplayName = "Demo Developer",
                        UserName = "DemoDev@bugtracker.com",
                        PasswordHash = passwordHasher.HashPassword(ConfigurationManager.AppSettings["DemoDeveloperPassword"])
                    },
                    new ApplicationUser
                    {
                        Email = "DemoProjectManager@bugtracker.com",
                        FirstName = "Demo",
                        LastName = "Project Manager",
                        DisplayName = "Demo Project Manager",
                        UserName = "DemoProjectManager@bugtracker.com",
                        PasswordHash = passwordHasher.HashPassword(ConfigurationManager.AppSettings["DemoProjectManagerPassword"])
                    },
                    new ApplicationUser
                    {
                        Email = "DemoAdmin@bugtracker.com",
                        FirstName = "Demo",
                        LastName = "Admin",
                        DisplayName = "Demo Admin",
                        UserName = "DemoAdmin@bugtracker.com",
                        PasswordHash = passwordHasher.HashPassword(ConfigurationManager.AppSettings["DemoAdminPassword"])
                    },
                    new ApplicationUser
                    {
                        Email = "DemoSubmitter@bugtracker.com",
                        FirstName = "Demo",
                        LastName = "Submitter",
                        DisplayName = "Demo Submitter",
                        UserName = "DemoSubmitter@bugtracker.com",
                        PasswordHash = passwordHasher.HashPassword(ConfigurationManager.AppSettings["DemoSubmitterPassword"])
                    }
                };

                string role = "";

                foreach(ApplicationUser user in users)
                {
                    role = user.FirstName == "Demo" ? user.DisplayName.Replace("Demo ", "").Replace(" ", "") : AppRoles.Admin;
                    userManager.Create(user);
                    userManager.AddToRole(user.Id, role);
                }

                changesApplied = true;
            }

            if (!context.TicketStatuses.Any())
            {
                foreach(string status in TicketStatuses.All)
                    context.TicketStatuses.Add(new TicketStatus { Name = status });

                changesApplied = true;
            }

            if (!context.TicketPriorities.Any())
            {
                foreach (string priority in TicketPriorities.All)
                    context.TicketPriorities.Add(new TicketPriority { Name = priority });

                changesApplied = true;
            }

            if (changesApplied)
                context.SaveChanges();
        }
    }
}
