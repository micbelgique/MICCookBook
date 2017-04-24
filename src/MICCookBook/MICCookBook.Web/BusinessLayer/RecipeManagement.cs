using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using MICCookBook.Web.BusinessLayer.Exceptions;
using MICCookBook.Web.Models;
using MICCookBook.Web.Services;
using MICCookBook.Web.ViewModels;

namespace MICCookBook.Web.BusinessLayer
{
    public class RecipeManagement : BaseManagement<RecipeManagement>
    {
        public RecipeManagement(IOwinContext owinContext) : base(owinContext)
        {
        }

        public async Task CreateNewRecipe(CreateRecipeViewModel model, IPrincipal user)
        {
            var fileStorageService = new LocalFileStorageService();
            var picturePath = fileStorageService.StoreFile(model.PictureFile);

            // create model
            var recipe = new Recipe()
            {
                Title = model.Title,
                Description = model.Description,
                Picture = picturePath,
                AuthorId = user.Identity.GetUserId()
            };

            // insert model in the database
            await UnitOfWork.Recipes.Add(recipe);

            // save changes
            await UnitOfWork.SaveChangesAsync();
        }

        public async Task UpdateRecipe(CreateRecipeViewModel model, IPrincipal user)
        {
            // retrieve model from database
            var recipe = await UnitOfWork.Recipes.GetById(model.Id);
            if (recipe == null)
                throw new EntityNotFoundException<Recipe, int>(model.Id, typeof(Recipe));

            // update model
            recipe.Title = model.Title;
            recipe.Description = model.Description;
            if (model.PictureFile != null)
            {
                var fileStorageService = new LocalFileStorageService();
                var picturePath = fileStorageService.StoreFile(model.PictureFile);
                recipe.Picture = picturePath;
            }

            // save changes of modified model
            await UnitOfWork.SaveChangesAsync();
        }
    }
}