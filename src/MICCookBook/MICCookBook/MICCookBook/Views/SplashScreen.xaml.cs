using System.Threading.Tasks;
using Xamarin.Forms;

namespace MICCookBook.Views
{
    public partial class SplashScreen
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            Device.BeginInvokeOnMainThread(async () =>
            {
                await Task.WhenAll(new[]
                {
                    BackgroundImage.TranslateTo(-60, 0, 20000),
                    Title.FadeTo(1, 1000, Easing.SinIn),
                    Title.TranslateTo(0, 0, 1000, Easing.SinOut)
                });
            });

            await Task.Delay(2500);

            Application.Current.MainPage = new MasterDetailPage();
        }
    }
}
