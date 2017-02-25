using System;
using System.Collections.Generic;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MICCookBook.XFCore.Services;
using MICCookBook.XFCore.Services.Navigation;
using MICCookBook.XFCore.Views;
using Xamarin.Forms;

namespace MICCookBook.XFCore.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        public List<NavigationMenuItem> NavigationMenuItems { get; set; }
        public ICommand NavigateCommand { get; set; }

        public MenuViewModel(MasterNavigation masterNavigation) : base(masterNavigation)
        {
            NavigationMenuItems = new List<NavigationMenuItem>();
            NavigationMenuItems.Add(new NavigationMenuItem() { Label = "Recipes", PageType = typeof(RecipeListView) });
            NavigationMenuItems.Add(new NavigationMenuItem() { Label = "Details", PageType = typeof(RecipeDetails) });
        }
    }

    public class NavigationMenuItem
    {
        public string Label { get; set; }
        public Type PageType { get; set; }

        public ICommand OnTapCommand { get; set; }

        public NavigationMenuItem()
        {
            OnTapCommand = new Command(async () =>
            {
                await (Application.Current as App).Navigation.Navigate(PageType);
                Messenger.Default.Send(new CloseMenuMessage());
            });
        }
    }
}
