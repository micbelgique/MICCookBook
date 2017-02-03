using System;
using System.Data.Entity;
using System.Data.Entity.Hooks.Fluent;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MICCookBook.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {

        }

        public static ApplicationDbContext Create()
        {
            var context = new ApplicationDbContext();

            context.CreateHook()
                .OnSave<IBaseModel>()
                .When(r => r.Id == 0)
                .Do(r => r.CreatedOn = r.ModifiedOn = DateTime.Now);

            context.CreateHook()
                .OnSave<IBaseModel>()
                .When(r => r.Id > 0)
                .Do(r => r.ModifiedOn = DateTime.Now);

            return context;
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
    }
}