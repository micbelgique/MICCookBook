using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace MICCookBook.Web.Models
{
    public class Recipe : IBaseModel
    {
        public int Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        // Relationships
        [ForeignKey("AuthorId")]
        public ApplicationUser Author { get; set; }
        public string AuthorId { get; set; }

        public List<Evaluation> Evaluations { get; set; }
    }
}