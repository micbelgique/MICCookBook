using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using MICCookBook.SDK;
using MICCookBook.SDK.Models;
using Xamarin.Forms;

namespace MICCookBook.ViewModels
{
    public class RecipesViewModel : BaseViewModel
    {
        private readonly CookBookClient _cookBookClient;
        private bool _isRefreshing;

        public ObservableCollection<Recipe> Recipes { get; set; }

        public ICommand RefreshCommand { get; set; }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set
            {
                _isRefreshing = value;
                RaisePropertyChanged();
            }
        }

        public RecipesViewModel()
        {
            _cookBookClient = new CookBookClient();

            Title = "Recipes";
            Recipes = new ObservableCollection<Recipe>();

            RefreshCommand = new Command(async () => await Load());
        }

        public override async Task OnAppearing()
        {
            await Load();
        }

        public async Task Load()
        {
            IsRefreshing = true;
            Recipes.Clear();
            var items = await _cookBookClient.GetRecipes();

            foreach (var item in items)
            {
                Recipes.Add(item);
                await Task.Delay(300);
            }
            IsRefreshing = false;
        }
    }
}
