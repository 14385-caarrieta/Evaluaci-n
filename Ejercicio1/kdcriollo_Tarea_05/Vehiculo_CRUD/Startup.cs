using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vehiculo_CRUD.Startup))]
namespace Vehiculo_CRUD
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
