using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace MICCookBook.ViewModels
{
    public class BaseViewModel : IViewModel
    {
        public virtual Task OnAppearing()
        {
            return Task.FromResult(0);
        }

        public virtual Task OnDisappearing()
        {
            return Task.FromResult(0);
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
