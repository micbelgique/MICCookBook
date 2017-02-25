using System.Threading;
using System.Web;
using System.Web.Mvc;
using MICCookBook.Web.Repository;
using Microsoft.AspNet.Identity.Owin;
using MICCookBook.Web.Controllers.ErrorHandlers;

namespace MICCookBook.Web.Controllers
{
    [EntityNotFoundHandler]
    public class BaseController : Controller
    {
        protected UnitOfWork UnitOfWork { get; private set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            //Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fr-FR");
            //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fr");
            UnitOfWork = HttpContext.GetOwinContext().Get<UnitOfWork>();
        }
    }
}