using GalaSoft.MvvmLight;
using MICCookBook.XFCore.Services;

namespace MICCookBook.XFCore.ViewModels
{
    public class BaseViewModel : ViewModelBase
    {
        protected readonly MasterNavigation MasterNavigation;

        public BaseViewModel(MasterNavigation masterNavigation)
        {
            MasterNavigation = masterNavigation;
        }
    }
}
