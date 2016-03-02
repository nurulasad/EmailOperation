using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EmailOperation.Startup))]
namespace EmailOperation
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
