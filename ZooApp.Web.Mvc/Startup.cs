using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ZooApp.Web.Mvc.Startup))]
namespace ZooApp.Web.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
