using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Rozgrywki.Startup))]
namespace Rozgrywki
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
