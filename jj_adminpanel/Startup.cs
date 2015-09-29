using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(jj_adminpanel.Startup))]
namespace jj_adminpanel
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
