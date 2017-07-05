using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Airport.WebApp.Startup))]
namespace Airport.WebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
