using SanityArchiver.Application.Models;
using System.Collections.ObjectModel;
using System.Linq;


namespace SanityArchiver.DesktopUI.ViewModels
{

    /// <summary>
    /// View model for application main Directory view 
    /// </summary>

    public class DirectoryStructureViewModel : BaseViewModel
    {
        #region Public Properties
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemVievModel> Items { get; set; }

    
    #endregion

    #region Constructor
    public DirectoryStructureViewModel()
    {
        var children = DirectoryStructure.GetLogicalDrives();
        this.Items = new ObservableCollection<DirectoryItemVievModel>(
            children.Select(drive => new DirectoryItemVievModel(drive.FullPath, Application.Models.Data.DirectoryItemType.Drive)));
    }

        #endregion
    }
}
