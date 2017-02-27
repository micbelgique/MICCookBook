using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MICCookBook.SDK;
using MICCookBook.SDK.Model;
using MICCookBook.XFCore.Services.Navigation;

namespace MICCookBook.XFCore.ViewModels
{
    public class RecipeListViewModel : BaseViewModel
    {
        private bool _isBusy;
        public ObservableCollection<Recipe> Recipes { get; set; }
        public ICommand AppearingCommand { get; set; }
        public ICommand RefreshCommand { get; set; }

        public DateTime LastRefresh { get; set; }

        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                RaisePropertyChanged();
            }
        }

        public RecipeListViewModel(MasterNavigation masterNavigation) : base(masterNavigation)
        {
            Recipes = new ObservableCollection<Recipe>();
            AppearingCommand = new RelayCommand(OnAppearingCommand);
            RefreshCommand = new RelayCommand(OnRefreshCommand);
        }

        private async void OnRefreshCommand()
        {
            await Refresh();
        }

        private async void OnAppearingCommand()
        {
            if (LastRefresh.AddMinutes(15) < DateTime.Now)
            {
                await Refresh();
            }
        }

        private async Task Refresh()
        {
            IsBusy = true;
            var cookBookClient = new CookBookClient();
            Recipes.Clear();
            var recipes = await cookBookClient.GetRecipes();
            foreach (var recipe in recipes)
            {
                Recipes.Add(recipe);
            }
            LastRefresh = DateTime.Now;
            IsBusy = false;
        }
    }
}
