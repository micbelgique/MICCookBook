using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using MICCookBook.Universal.Annotations;

namespace MICCookBook.Universal.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual Task OnAppearing()
        {
            return Task.FromResult(0);
        }

        public virtual Task OnDisappearing()
        {
            return Task.FromResult(0);
        }
    }
}
