using System.ComponentModel;
using PropertyChanged;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// A base View Model that fires Property Changed events as needed.
    /// </summary>
    [AddINotifyPropertyChangedInterface]

    public class BaseViewModel : INotifyPropertyChanged
    {
        //Event is fired when the value of P
        public event PropertyChangedEventHandler PropertyChanged = (sender, e) => { };
    }
}