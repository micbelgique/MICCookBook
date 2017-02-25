using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MICCookBook.XFCore.Services.Navigation
{
    public class MasterNavigation
    {
        private INavigation _navigation;

        public Queue<Page> PageStack { get; set; }

        public Dictionary<Type, Page> Pages { get; set; }

        public MasterNavigation()
        {
            Pages = new Dictionary<Type, Page>();
            PageStack = new Queue<Page>();
        }

        public async Task Navigate<T>() where T : Page
        {
            var pageType = typeof(T);
            T page = null;
            if (Pages.ContainsKey(pageType))
            {
                page = (T)Pages[typeof(T)];
            }
            else
            {
                page = Activator.CreateInstance<T>();
            }

            await Navigate(page);
        }

        internal async Task Navigate(Type pageType)
        {
            Page page = null;
            if (Pages.ContainsKey(pageType))
            {
                page = Pages[pageType];
            }
            else
            {
                page = (Page)Activator.CreateInstance(pageType);
            }

            await Navigate(page);
        }

        private async Task Navigate<T>(T page) where T : Page
        {
            if (page is IPageRoot || _navigation == null)
            {
                Application.Current.MainPage = page;
                if (page is IPageNavigation)
                {
                    _navigation = ((IPageNavigation)page).NavigationRoot;
                }
                else
                {
                    _navigation = null;
                }
            }
            else
            {
                await _navigation.PushAsync(page);
            }
        }

        public async Task GoBack()
        {
            if (_navigation != null)
            {
                await _navigation.PopAsync();
            }
        }
    }
}
