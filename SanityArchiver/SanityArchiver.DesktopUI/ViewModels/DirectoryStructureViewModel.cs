using System.Collections.Generic;
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
        
        public static List<DirectoryItemVievModel> Selected { get; set; }
        
        public DirectoryStructureViewModel()
    {
        var children = DirectoryStructure.GetLogicalDrives();
        Selected = new List<DirectoryItemVievModel>();
        Items = new ObservableCollection<DirectoryItemVievModel>(
            children.Select(drive => new DirectoryItemVievModel(drive.FullPath, DirectoryItemType.Drive)));
    }
    }
}
