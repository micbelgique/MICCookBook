using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Repository
{
    public class RecipeRepository : BaseModelRepository<Recipe>
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Recipe>> GetAllAsync(bool includeRelatedData)
        {
            if (includeRelatedData)
                return await Context.Recipes
                    .Include(r => r.Author)
                    .Include(r => r.Evaluations)
                    .ToListAsync();

            return await GetAllAsync();
        }

        public async Task<List<Recipe>> GetAllAsync(Expression<Func<Recipe, bool>> predicate)
        {
            return await Context.Recipes
                .Where(predicate)
                .ToListAsync();
        }

        public async Task<List<Recipe>> GetAllAsync(Expression<Func<Recipe, bool>> predicate, bool includeRelatedData)
        {
            if (includeRelatedData)
                return await Context.Recipes
                    .Include(r => r.Author)
                    .Include(r => r.Evaluations)
                    .Where(predicate)
                    .ToListAsync();

            return await GetAllAsync(predicate);
        }
    }
}