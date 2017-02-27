using GalaSoft.MvvmLight.Messaging;
using MICCookBook.XFCore.Services.Navigation;
using Xamarin.Forms;

namespace MICCookBook.XFCore.Views
{
    public partial class MainPage : MasterDetailPage, IPageRoot, IPageNavigation
    {
        public MainPage()
        {
            InitializeComponent();
            Messenger.Default.Register<CloseMenuMessage>(this, OnMenuClose);
        }

        private void OnMenuClose(CloseMenuMessage obj)
        {
            IsPresented = false;
        }

        public INavigation NavigationRoot => Detail.Navigation;
    }
}
