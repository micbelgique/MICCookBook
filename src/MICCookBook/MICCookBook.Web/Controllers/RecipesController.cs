using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MICCookBook.Web.Models;
using MICCookBook.Web.Services;
using MICCookBook.Web.ViewModels;

namespace MICCookBook.Web.Controllers
{
    public class RecipesController : Controller
    {
        // GET: Recipes
        public async Task<ActionResult> Index()
        {
            var context = new ApplicationDbContext();
            var recipes = await context.Recipes.Include(r => r.Author).ToListAsync();
            return View(recipes);
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
                // TODO: Add insert logic here
                var fileStorageService = new LocalFileStorageService(Server);
                var picturePath = fileStorageService.StoreFile(model.PictureFile);

                var recipe = new Recipe()
                {
                    Title = model.Title,
                    Description = model.Description,
                    Picture = picturePath,
                    AuthorId = User.Identity.GetUserId()
                };

                var context = new ApplicationDbContext();
                context.Recipes.Add(recipe);
                await context.SaveChangesAsync();

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
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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
