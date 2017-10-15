using GalaSoft.MvvmLight.Ioc;

namespace MICCookBook.Universal.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            SimpleIoc.Default.Register<HomeViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
        }

        public HomeViewModel Home => SimpleIoc.Default.GetInstance<HomeViewModel>();
        public MenuViewModel Menu => SimpleIoc.Default.GetInstance<MenuViewModel>();
    }
}
