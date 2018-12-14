using System.Collections.Generic;

namespace SanityArchiver.DesktopUI.ViewModels
{
    public class ArchiveViewModel
    {
        public ArchiveViewModel(List<DirectoryItemVievModel> elementsToArchive)
        {
            ElementsToArchive = elementsToArchive;
            foreach (var element in ElementsToArchive)
            {
                ElementsToDisplay.Add(element.Name);
            }
        }

        public List<DirectoryItemVievModel> ElementsToArchive { get; set; }

        public List<string> ElementsToDisplay { get; set; } = new List<string>();

        
    }
}