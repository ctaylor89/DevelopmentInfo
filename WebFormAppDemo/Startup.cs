using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebFormAppDemo.Startup))]
namespace WebFormAppDemo
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
