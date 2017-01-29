using System;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace MICCookBook.Web.BusinessLayer
{
    public class BaseManagement<T> : IDisposable
        where T : IDisposable
    {
        public IOwinContext OwinContext { get; set; }

        public BaseManagement(IOwinContext owinContext)
        {
            OwinContext = owinContext;
        }

        public static T Create(IdentityFactoryOptions<T> factory, IOwinContext context)

        {
            return (T)Activator.CreateInstance(typeof(T), context);
        }

        public void Dispose()
        {
        }
    }
}