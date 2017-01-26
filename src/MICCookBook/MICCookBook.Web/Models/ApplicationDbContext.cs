using System;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MICCookBook.Web.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Evaluation> Evaluations { get; set; }
    }
}