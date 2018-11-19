using MICCookBook.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MICCookBook.ViewModels
{
    public class RecipeDetailsViewModel : BaseViewModel
    {
        public RecipeDetailsViewModel()
        {

        }

        public RecipeDetailsViewModel(Recipe recipe) : this()
        {
            Recipe = recipe;
            Title = $"{Recipe.Title} Details";
        }

        private Recipe recipe;
        public Recipe Recipe
        {
            get => recipe;
            set
            {
                if (recipe == value)
                    return;

                recipe = value;
                RaisePropertyChanged();
            }
        }
    }
}
