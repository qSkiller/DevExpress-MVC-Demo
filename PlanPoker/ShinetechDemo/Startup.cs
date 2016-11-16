using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ShinetechDemo.Startup))]
namespace ShinetechDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
