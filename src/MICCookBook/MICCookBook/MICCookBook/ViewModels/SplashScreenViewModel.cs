using GalaSoft.MvvmLight.Command;
using MICCookBook.XFCore.Services;
using MICCookBook.XFCore.Services.Navigation;
using MICCookBook.XFCore.Views;
using Xamarin.Forms;

namespace MICCookBook.XFCore.ViewModels
{
    public class SplashScreenViewModel: BaseViewModel
    {
        public RelayCommand EnterCommand { get; set; }

        public SplashScreenViewModel(MasterNavigation masterNavigation) : base(masterNavigation)
        {
            EnterCommand = new RelayCommand(OnEnterCommand);
        }

        private async void OnEnterCommand()
        {
            await (Application.Current as App).Navigation.Navigate<MainPage>();
        }
    }
}
