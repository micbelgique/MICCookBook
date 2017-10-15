using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MICCookBook.SDK;
using MICCookBook.SDK.Models;

namespace MICCookBook.Universal.ViewModels
{
    public class HomeViewModel: BaseViewModel
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

        public HomeViewModel()
        {
            _cookBookClient = new CookBookClient();

            Recipes = new ObservableCollection<Recipe>();

            RefreshCommand = new RelayCommand(async () => await Load());
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
