using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Controllers.API
{
    [Authorize]
    // Use Bearer token authentication
    public class ProfileController : BaseApiController
    {
        public string Get()
        {
            return User.Identity.GetUserName();
        }

        [AllowAnonymous]
        [Route("api/profile/recipes")]
        public async Task<List<Recipe>> GetRecipes()
        {
            var userId = User.Identity.GetUserId();
            return await UnitOfWork.Recipes.GetAllAsync(r => r.AuthorId == userId, true);
        }
    }
}