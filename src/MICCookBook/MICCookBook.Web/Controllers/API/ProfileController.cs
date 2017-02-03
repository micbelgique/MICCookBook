using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using MICCookBook.Web.Controllers.API.Auth;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Controllers.API
{
    [IdentityBasicAuthentication]
    public class ProfileController : BaseApiController
    {
        public string Get()
        {
            return User.Identity.GetUserName();
        }

        [Route("api/profile/recipes")]
        public async Task<List<Recipe>> GetRecipes()
        {
            var userId = User.Identity.GetUserId();
            return await UnitOfWork.Recipes.GetAllAsync(r => r.AuthorId == userId);
        }
    }
}