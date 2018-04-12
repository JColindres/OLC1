using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_OLC_Practica2.Startup))]
namespace _OLC_Practica2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
