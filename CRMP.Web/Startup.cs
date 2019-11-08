using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMP.Web.Startup))]
namespace CRMP.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
