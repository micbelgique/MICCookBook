using System.Web;
using System.Web.Mvc;
using MICCookBook.Web.Repository;
using Microsoft.AspNet.Identity.Owin;

namespace MICCookBook.Web.Controllers
{
    public class BaseController : Controller
    {
        protected UnitOfWork UnitOfWork { get; private set; }
        public BaseController()
        {
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            UnitOfWork = HttpContext.GetOwinContext().Get<UnitOfWork>();
        }
    }
}