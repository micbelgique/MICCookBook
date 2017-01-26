using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MICCookBook.Web.Models
{
    public class Evaluation
    {
        public int Rating { get; set; }
        public string Comment { get; set; }

        // Relationships
        public ApplicationUser Author { get; set; }
        public int AuthorId { get; set; }

        public Recipe Recipe { get; set; }
        public int RecipeId { get; set; }
    }
}