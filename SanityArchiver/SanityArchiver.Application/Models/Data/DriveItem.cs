using System.IO;

namespace SanityArchiver.Application.Models.Data
{
    public class DriveItem : Item
    {
        public string FullPath { get; set; }
        
        public string Name
        {
            get { return FullPath; }
        }
    }
}