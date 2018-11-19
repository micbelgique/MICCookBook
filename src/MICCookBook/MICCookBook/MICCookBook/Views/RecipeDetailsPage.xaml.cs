using MICCookBook.SDK.Models;
using MICCookBook.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MICCookBook.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class RecipeDetailsPage : ContentPage
	{
        public RecipeDetailsPage()
        {
            InitializeComponent();
        }

        public RecipeDetailsPage(Recipe recipe)
		{
			InitializeComponent();
            BindingContext = new RecipeDetailsViewModel(recipe);
        }
	}
}