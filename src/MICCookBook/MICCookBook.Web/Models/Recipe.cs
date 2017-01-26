using System.Collections.Generic;

namespace MICCookBook.Web.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        // Relationships
        public ApplicationUser Author { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}