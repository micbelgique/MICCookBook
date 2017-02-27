using System;
using Microsoft.Owin;
using Microsoft.Owin.Security.OAuth;
using MICCookBook.Web.Controllers.API.Auth;
using Owin;

[assembly: OwinStartupAttribute(typeof(MICCookBook.Web.Startup))]
namespace MICCookBook.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
        }
    }
}
