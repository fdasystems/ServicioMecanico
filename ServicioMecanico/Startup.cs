using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServicioMecanico.Startup))]
namespace ServicioMecanico
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
