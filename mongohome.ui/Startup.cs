using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(mongohome.ui.Startup))]
namespace mongohome.ui
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
