using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRM.Site.Startup))]
namespace CRM.Site
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
