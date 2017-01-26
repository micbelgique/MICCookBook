using System.Collections.Generic;
using System.Web;
using MICCookBook.Web.Models;

namespace MICCookBook.Web.ViewModels
{
    public class CreateRecipeViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public HttpPostedFileBase PictureFile { get; set; }
        public List<Evaluation> Evaluations { get; set; }
    }
}