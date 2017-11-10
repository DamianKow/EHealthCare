using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EHealthCare.Web.Startup))]
namespace EHealthCare.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
