using System;
using GalaSoft.MvvmLight.Views;
using Xamarin.Forms;

namespace MICCookBook.XFCore.Services
{
    public class MasterNavigation : NavigationService
    {
        public void ReplaceRoot<T>() where T : Page
        {
            var page = Activator.CreateInstance<T>();
            Application.Current.MainPage = new NavigationPage(page);
        }
    }
}
