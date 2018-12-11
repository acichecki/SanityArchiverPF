using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// Basic command that runs an Action
    /// </summary>
    public class RelayCommand : ICommand
    {
        #region Private Memvers
        //Action to run
        private Action mAction;
        #endregion

        #region Public Events
        /// <summary>
        /// The event thats fired when the <see cref="CanExecute(object)"/> value has changed
        /// </summary>
        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion

        #region Constructor
        public RelayCommand (Action action)
        {
            mAction = action;
        }


        #endregion

        #region Command Methods

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            mAction();
        }

        #endregion
    }
}
