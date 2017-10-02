using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(yourTrip.Startup))]
namespace yourTrip
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
