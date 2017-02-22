using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MICCookBook.XFCore.Services.Navigation
{
    public interface IPageNavigation
    {
        INavigation NavigationRoot { get; }
    }
}
