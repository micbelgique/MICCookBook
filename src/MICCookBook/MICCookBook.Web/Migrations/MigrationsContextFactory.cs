using System.Data.Entity.Infrastructure;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.Migrations
{
    public class MigrationsContextFactory : IDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext Create()
        {
            return ApplicationDbContext.Create();
        }
    }
}