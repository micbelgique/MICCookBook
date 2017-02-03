using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.ViewModels
{
    public class CreateRecipeViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public string Picture { get; set; }
        [Required]
        public HttpPostedFileBase PictureFile { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}