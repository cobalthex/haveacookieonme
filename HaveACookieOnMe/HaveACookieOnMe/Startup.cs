using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HaveACookieOnMe.Startup))]
namespace HaveACookieOnMe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
