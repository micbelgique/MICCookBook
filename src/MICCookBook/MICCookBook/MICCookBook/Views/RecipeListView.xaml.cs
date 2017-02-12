using MICCookBook.XFCore.ViewModels;
using Xamarin.Forms;

namespace MICCookBook.XFCore.Views
{
    public partial class RecipeList : ContentPage
    {
        public RecipeList()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var vm = this.BindingContext as MainPageViewModel;
            vm.OnAppearing();
        }
    }
}
