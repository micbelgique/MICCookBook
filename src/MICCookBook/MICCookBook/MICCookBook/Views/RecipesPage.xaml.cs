using MICCookBook.SDK.Models;
using MICCookBook.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MICCookBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage
    {
        public RecipesPage()
        {
            InitializeComponent();

            BindingContext = new RecipesViewModel();
        }

        protected override void OnAppearing()
        {
            ((IViewModel) BindingContext).OnAppearing();
        }

        protected override void OnDisappearing()
        {
            ((IViewModel)BindingContext).OnDisappearing();
        }

        private async void ListView_ItemSelectedAsync(object sender, SelectedItemChangedEventArgs e)
        {
            var recipe = e.SelectedItem as Recipe;
            if (recipe == null)
                return;

            await Navigation.PushAsync(new RecipeDetailsPage(recipe));

            ((ListView)sender).SelectedItem = null;
        }
    }
}