using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using MICCookBook.Web.BusinessLayer;
using MICCookBook.Web.Extensions;
using MICCookBook.Web.Models;
using MICCookBook.Web.Repository;
using MICCookBook.Web.Services;
using MICCookBook.Web.ViewModels;

namespace MICCookBook.Web.Controllers
{
    public class RecipesController : BaseController
    {
        public RecipesController()
        {

        }

        // GET: Recipes
        public async Task<ActionResult> Index()
        {
            var recipes = await UnitOfWork.Recipes.GetAllAsync(r => r.Author);

            return View(recipes);
        }

        // GET: Recipes/Details/5
        public async Task<ActionResult> Details(int id, string slug)
        {
            var unitOfWork = HttpContext.GetOwinContext().Get<UnitOfWork>();

            var recipe = await unitOfWork.Recipes.GetById(id);
            if (recipe != null && recipe.Title.ToSlug() == slug)
            {
                return View(recipe);
            }

            return HttpNotFound();
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipes/Create
        [HttpPost]
        public async Task<ActionResult> Create(CreateRecipeViewModel model)
        {
            try
            {
                var recipeManagement = HttpContext.GetOwinContext().Get<RecipeManagement>();
                await recipeManagement.CreateNewRecipe(model, User);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recipes/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, CreateRecipeViewModel model)
        {
            try
            {
                // TODO: Add update logic here
                model.Id = id;
                var recipeManagement = HttpContext.GetOwinContext().Get<RecipeManagement>();
                await recipeManagement.UpdateRecipe(model, User);
                
                return RedirectToAction("Details", new { id });
            }
            catch 
            {
                return View();
            }
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recipes/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
