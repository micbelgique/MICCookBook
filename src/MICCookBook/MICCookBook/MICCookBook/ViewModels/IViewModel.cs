using System.ComponentModel;
using System.Threading.Tasks;

namespace MICCookBook.ViewModels
{
    public interface IViewModel : INotifyPropertyChanged
    {
        Task OnAppearing();
        Task OnDisappearing();
    }
}
