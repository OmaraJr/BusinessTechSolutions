using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BusinessTechSolutions.Startup))]
namespace BusinessTechSolutions
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
