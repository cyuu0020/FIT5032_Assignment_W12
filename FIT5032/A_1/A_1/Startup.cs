using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A_1.Startup))]
namespace A_1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
