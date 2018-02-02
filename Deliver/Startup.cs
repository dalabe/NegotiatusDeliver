using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Deliver.Startup))]
namespace Deliver
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
