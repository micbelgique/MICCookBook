using System;
using System.Collections.Generic;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;
using FontAwesome.Portable;
using MICCookBook.Universal.Views;

namespace MICCookBook.Universal.ViewModels
{
    public class MenuViewModel
    {
        private MenuItem _selectedMenu;
        public Frame Frame { get; set; }

        public List<MenuItem> MenuItems { get; set; }

        public MenuViewModel()
        {
            Frame = new Frame();

            MenuItems = new List<MenuItem>()
            {
                new MenuItem()
                {
                    Page = typeof(HomePage),
                    Label = "Accueil",
                    Icon = FontAwesomeIcon.Home
                },
                new MenuItem()
                {
                    Page = typeof(AboutPage),
                    Label = "À propos",
                    Icon = FontAwesomeIcon.Question
                }
            };
        }

        public MenuItem SelectedMenu
        {
            get { return _selectedMenu; }
            set
            {
                _selectedMenu = value;
                Navigate(_selectedMenu);
            }
        }

        private void Navigate(MenuItem selectedMenu)
        {
            Page page = Frame?.Content as Page;
            if (page?.GetType() != selectedMenu.Page)
            {
                Frame?.Navigate(selectedMenu.Page);
            }
        }
    }

    public class MenuItem
    {
        public Type Page { get; set; }
        public string Label { get; set; }
        public FontAwesomeIcon Icon { get; set; }
    }
}
