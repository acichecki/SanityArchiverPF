using System.Collections.ObjectModel;
using System.Linq;
using SanityArchiver.Application.Models;
using SanityArchiver.Application.Models.Data;

namespace SanityArchiver.DesktopUI.ViewModels
{

    /// <summary>
    /// View model for application main Directory view 
    /// </summary>

    public class DirectoryStructureViewModel : BaseViewModel
    {
        /// <summary>
        /// A list of all directories on the machine
        /// </summary>
        public ObservableCollection<DirectoryItemVievModel> Items { get; set; }


        public DirectoryStructureViewModel()
    {
        var children = DirectoryStructure.GetLogicalDrives();
        Items = new ObservableCollection<DirectoryItemVievModel>(
            children.Select(drive => new DirectoryItemVievModel(drive.FullPath, DirectoryItemType.Drive)));
    }
    }
}
