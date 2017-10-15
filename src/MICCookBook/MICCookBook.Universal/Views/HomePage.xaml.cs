using Windows.UI.Xaml;
using Windows.UI.Xaml.Navigation;
using MICCookBook.Universal.ViewModels;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace MICCookBook.Universal.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePage
    {
        public HomePage()
        {
            this.InitializeComponent();

            DataContext = (Application.Current.Resources["Locator"] as ViewModelLocator)?.Home;
        }

        private void HomePage_DataContextChanged(Windows.UI.Xaml.FrameworkElement sender, Windows.UI.Xaml.DataContextChangedEventArgs args)
        {
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            (DataContext as IViewModel)?.OnAppearing();
        }
    }
}
