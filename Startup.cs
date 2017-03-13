using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCAssignment7.Startup))]
namespace MVCAssignment7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
