using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRESENTACION.Startup))]
namespace PRESENTACION
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
