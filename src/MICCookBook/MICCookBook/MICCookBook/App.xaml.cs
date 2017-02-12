using MICCookBook.XFCore.Views;
using Xamarin.Forms;

namespace MICCookBook.XFCore
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new SplashScreen();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
