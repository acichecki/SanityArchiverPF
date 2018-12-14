using System;
using System.Windows.Input;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// Basic command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        //Action to run
        private Action mAction;

        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayCommand (Action action)
        {
            mAction = action;
        }


        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }
    }
}
