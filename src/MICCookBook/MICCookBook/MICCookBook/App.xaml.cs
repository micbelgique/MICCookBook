using MICCookBook.XFCore.Services.Navigation;
using MICCookBook.XFCore.Views;
using Xamarin.Forms;

namespace MICCookBook.XFCore
{
    public partial class App : Application
    {
        public MasterNavigation Navigation { get; set; }
        public App()
        {
            InitializeComponent();
            Navigation = new MasterNavigation();
            MainPage = new SplashScreen();
        }

        protected override async void OnStart()
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
