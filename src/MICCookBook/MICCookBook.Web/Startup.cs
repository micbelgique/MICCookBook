using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MICCookBook.Web.Startup))]
namespace MICCookBook.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
