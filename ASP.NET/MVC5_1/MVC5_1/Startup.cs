using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVC5_1.Startup))]
namespace MVC5_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
