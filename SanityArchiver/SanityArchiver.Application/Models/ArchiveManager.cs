using System.Collections.Generic;

namespace SanityArchiver.Application.Models
{

    public class ArchiveManager
    {
        private List<string> filesToArchive;

        public ArchiveManager(List<string> filesToArchive)
        {
            this.filesToArchive = filesToArchive;
        }

        
    }
}