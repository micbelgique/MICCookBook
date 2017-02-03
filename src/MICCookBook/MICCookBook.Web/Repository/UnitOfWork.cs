using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Repository
{
    public class UnitOfWork : IDisposable
    {
        private readonly ApplicationDbContext _context;
        private RecipeRepository _recipeRepository;
        private EvaluationRepository _evaluationRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public static UnitOfWork Create(IdentityFactoryOptions<UnitOfWork> factory, IOwinContext context)
        {
            return new UnitOfWork(context.Get<ApplicationDbContext>());
        }

        public void Dispose()
        {
            _context?.Dispose();
        }

        public RecipeRepository Recipes => _recipeRepository ?? (_recipeRepository = new RecipeRepository(_context));

        public EvaluationRepository Evaluations => _evaluationRepository ?? (_evaluationRepository = new EvaluationRepository(_context));

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

}