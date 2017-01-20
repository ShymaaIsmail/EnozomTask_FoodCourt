using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnozomFoodcourtTask.Startup))]
namespace EnozomFoodcourtTask
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
