using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebTaskManager.Startup))]
namespace WebTaskManager
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
