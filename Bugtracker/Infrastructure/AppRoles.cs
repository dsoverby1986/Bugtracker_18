using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bugtracker.Infrastructure
{
    public static class AppRoles
    {
        public const string Admin = nameof(Admin);
        public const string ProjectManager = nameof(ProjectManager);
        public const string Developer = nameof(Developer);
        public const string Submitter = nameof(Submitter);
        public const string Demoer = nameof(Demoer);

        public static string[] All => new string[] { Admin, ProjectManager, Developer, Submitter, Demoer };
    }
}