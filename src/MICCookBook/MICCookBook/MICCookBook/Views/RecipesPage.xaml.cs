using MICCookBook.ViewModels;
using Xamarin.Forms.Xaml;

namespace MICCookBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesPage
    {
        public RecipesPage()
        {
            InitializeComponent();

            BindingContext = new RecipesViewModel();
        }

        protected override void OnAppearing()
        {
            ((IViewModel) BindingContext).OnAppearing();
        }

        protected override void OnDisappearing()
        {
            ((IViewModel)BindingContext).OnDisappearing();
        }
    }
}