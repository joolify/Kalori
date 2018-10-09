using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Kalori.Startup))]
namespace Kalori
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
