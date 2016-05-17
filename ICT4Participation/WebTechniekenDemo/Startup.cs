using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTechniekenDemo.Startup))]
namespace WebTechniekenDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
