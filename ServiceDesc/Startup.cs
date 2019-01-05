using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ServiceDesc.Startup))]
namespace ServiceDesc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
