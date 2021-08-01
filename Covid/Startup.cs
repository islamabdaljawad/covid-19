using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Covid.Startup))]
namespace Covid
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
