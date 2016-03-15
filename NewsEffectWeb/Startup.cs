using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NewsEffectWeb.Startup))]
namespace NewsEffectWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
