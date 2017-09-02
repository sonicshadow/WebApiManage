using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebApiManage.Startup))]
namespace WebApiManage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
