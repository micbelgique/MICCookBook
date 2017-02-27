using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;
using MICCookBook.XFCore.Services;
using MICCookBook.XFCore.Services.Navigation;

namespace MICCookBook.XFCore.ViewModels
{
    /// <summary>
    /// This class contains static references to all the view models in the
    /// application and provides an entry point for the bindings.
    /// </summary>
    public class ViewModelLocator
    {
        /// <summary>
        /// Initializes a new instance of the ViewModelLocator class.
        /// </summary>
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            ////if (ViewModelBase.IsInDesignModeStatic)
            ////{
            ////    // Create design time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DesignDataService>();
            ////}
            ////else
            ////{
            ////    // Create run time view services and models
            ////    SimpleIoc.Default.Register<IDataService, DataService>();
            ////}

            SimpleIoc.Default.Register<MasterNavigation>();
            SimpleIoc.Default.Register<SplashScreenViewModel>();
            SimpleIoc.Default.Register<RecipeListViewModel>();
            SimpleIoc.Default.Register<MenuViewModel>();
        }

        public SplashScreenViewModel SplashScreen => ServiceLocator.Current.GetInstance<SplashScreenViewModel>();
        public RecipeListViewModel RecipesList => ServiceLocator.Current.GetInstance<RecipeListViewModel>();
        public MenuViewModel Menu => ServiceLocator.Current.GetInstance<MenuViewModel>();

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }
    }
}
