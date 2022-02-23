using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SATProject.UI.MVC.Startup))]
namespace SATProject.UI.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
