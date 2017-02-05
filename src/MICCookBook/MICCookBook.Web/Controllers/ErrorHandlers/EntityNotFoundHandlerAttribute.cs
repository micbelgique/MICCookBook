using System.Web.Mvc;
using MICCookBook.Web.BusinessLayer.Exceptions;

namespace MICCookBook.Web.Controllers.ErrorHandlers
{
    // https://www.codeproject.com/Articles/850062/Exception-handling-in-ASP-NET-MVC-methods-explaine
    public class EntityNotFoundHandlerAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.Exception is IEntityNotFoundException)
            {
                filterContext.ExceptionHandled = true;

                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                filterContext.Result = new ViewResult()
                {
                    ViewName = "NotFound",
                    ViewData = new ViewDataDictionary(model)
                };
            }
        }
    }
}