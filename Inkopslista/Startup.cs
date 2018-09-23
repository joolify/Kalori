using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Inkopslista.Startup))]
namespace Inkopslista
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
