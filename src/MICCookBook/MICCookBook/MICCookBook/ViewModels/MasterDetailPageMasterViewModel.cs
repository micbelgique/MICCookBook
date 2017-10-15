using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using MICCookBook.Views;

namespace MICCookBook.ViewModels
{
    public class MasterDetailPageMasterViewModel : BaseViewModel
    {
        public ObservableCollection<MasterDetailPageMenuItem> MenuItems { get; set; }

        public MasterDetailPageMasterViewModel()
        {
            MenuItems = new ObservableCollection<MasterDetailPageMenuItem>(new[]
            {
                new MasterDetailPageMenuItem { Id = 0, Title = "Accueil" },
                new MasterDetailPageMenuItem { Id = 1, Title = "À propos" },
            });
        }

    }
}
