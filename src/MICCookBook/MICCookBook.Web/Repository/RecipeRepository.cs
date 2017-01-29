using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Repository
{
    public class RecipeRepository : BaseModelRepository<Recipe>
    {
        public RecipeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Recipe>> GetAllAsync(bool includeRelatedData = true)
        {
            if (includeRelatedData)
                return await Context.Recipes
                    .Include(r => r.Author)
                    .Include(r => r.Evaluations)
                    .ToListAsync();

            return await GetAllAsync();
        }
    }
}