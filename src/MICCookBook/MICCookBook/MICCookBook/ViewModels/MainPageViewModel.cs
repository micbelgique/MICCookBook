using System.Collections.ObjectModel;
using MICCookBook.SDK;
using MICCookBook.SDK.Model;
using MICCookBook.XFCore.Services;

namespace MICCookBook.XFCore.ViewModels
{
    public class MainPageViewModel : BaseViewModel
    {
        public ObservableCollection<Recipe> Recipes { get; set; }

        public MainPageViewModel(MasterNavigation masterNavigation) : base(masterNavigation)
        {
            Recipes = new ObservableCollection<Recipe>();
        }

        public async void OnAppearing()
        {
            var cookBookClient = new CookBookClient();
            var recipes = await cookBookClient.GetRecipes();
            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe);
            }
        }
    }
}
