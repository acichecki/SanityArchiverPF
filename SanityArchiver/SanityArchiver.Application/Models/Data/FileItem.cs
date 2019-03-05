using System.ComponentModel.Design;
using System.IO;

namespace SanityArchiver.Application.Models.Data
{
    public class FileItem : Item
    {
        private FileInfo fullPath;

        public FileInfo getFullPath()
        {
            return fullPath;
        }

        public void setFullPath(string value)
        {
            fullPath = new FileInfo(value);
        }
    }
}