using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BGTracker.WebMVC.Startup))]
namespace BGTracker.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
