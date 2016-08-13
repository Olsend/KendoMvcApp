using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KendoMvcApp.Startup))]
namespace KendoMvcApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
