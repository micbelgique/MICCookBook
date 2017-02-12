using GalaSoft.MvvmLight.Command;
using MICCookBook.XFCore.Services;
using MICCookBook.XFCore.Views;

namespace MICCookBook.XFCore.ViewModels
{
    public class SplashScreenViewModel: BaseViewModel
    {
        public RelayCommand EnterCommand { get; set; }

        public SplashScreenViewModel(MasterNavigation masterNavigation) : base(masterNavigation)
        {
            EnterCommand = new RelayCommand(OnEnterCommand);
        }

        private void OnEnterCommand()
        {
            MasterNavigation.ReplaceRoot<MainPage>();
        }
    }
}
