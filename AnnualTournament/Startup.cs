using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AnnualTournament.Startup))]
namespace AnnualTournament
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
