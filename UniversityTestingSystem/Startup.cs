using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(UniversityTestingSystem.Startup))]
namespace UniversityTestingSystem
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
