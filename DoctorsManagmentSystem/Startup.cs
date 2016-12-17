using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(DoctorsManagmentSystem.Startup))]
namespace DoctorsManagmentSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
