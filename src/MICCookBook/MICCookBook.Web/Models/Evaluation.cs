using System;

namespace MICCookBook.Web.Models
{
    public class Evaluation : IBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public int Rating { get; set; }
        public string Comment { get; set; }

        // Relationships
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }

        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}