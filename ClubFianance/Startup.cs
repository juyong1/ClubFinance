using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClubFinance.Startup))]
namespace ClubFinance
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
