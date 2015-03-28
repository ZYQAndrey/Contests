using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MSContests.Startup))]
namespace MSContests
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
