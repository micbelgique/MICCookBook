using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using Microsoft.AspNet.Identity.Owin;
using MICCookBook.Web.Repository;

namespace MICCookBook.Web.Controllers.API
{
    public class BaseApiController : ApiController
    {
        protected UnitOfWork UnitOfWork { get; private set; }

        protected override void Initialize(HttpControllerContext controllerContext)
        {
            UnitOfWork = HttpContext.Current.GetOwinContext().Get<UnitOfWork>();
            base.Initialize(controllerContext);
        }

        public override Task<HttpResponseMessage> ExecuteAsync(HttpControllerContext controllerContext, CancellationToken cancellationToken)
        {
            UnitOfWork = HttpContext.Current.GetOwinContext().Get<UnitOfWork>();
            return base.ExecuteAsync(controllerContext, cancellationToken);
        }
    }
}