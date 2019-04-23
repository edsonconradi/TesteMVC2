using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Infra.Mvc.Startup))]
namespace Infra.Mvc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
