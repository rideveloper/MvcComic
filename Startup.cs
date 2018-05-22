using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcComic.Startup))]
namespace MvcComic
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
