namespace SanityArchiver.Application.Models.Data
{
    /// <summary>
    /// Information about a dirctory item such as drive, file or folder.
    /// </summary>
    public class DirectoryItem
    {
        // Type of this item
        public DirectoryItemType Type { get; set; }

        // Absolute path to this item
        public string FullPath { get; set; }


        //Name of directory item
        public string Name { get { return this.Type == DirectoryItemType.Drive ? this.FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }
        
    }
}
