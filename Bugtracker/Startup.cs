using Microsoft.Owin;
using Owin;
using Bugtracker.Migrations;

[assembly: OwinStartupAttribute(typeof(Bugtracker.Startup))]
namespace Bugtracker
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
