using MICCookBook.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MICCookBook.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterDetailPageMaster : ContentPage
    {
        public ListView ListView { get; set; }

        public MasterDetailPageMaster()
        {
            InitializeComponent();

            BindingContext = new MasterDetailPageMasterViewModel();

            ListView = MenuItemsListView;
        }
    }
}