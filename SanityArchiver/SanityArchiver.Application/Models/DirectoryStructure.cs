using SanityArchiver.Application.Models.Data;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SanityArchiver.Application.Models
{
    public static class DirectoryStructure
    {
        /// <summary>
        /// Gets all logical drives on the computer.
        /// </summary>
        /// <returns>List of local drives.</returns>
        public static List<DirectoryItem> GetLogicalDrives()
        {
           return Directory.GetLogicalDrives().Select(drive => new DirectoryItem { FullPath = drive, Type = DirectoryItemType.Drive}).ToList();
        }

    
    /// <summary>
    /// Gets the directories content
    /// </summary>
    /// <param name="fullPath">The full path to the directory</param>
    /// <returns></returns>
    public static List<DirectoryItem> GetDirectoryContents(string fullPath)
        {
            var items = new List<DirectoryItem>();
            //Add directories to the list
                try
                {
                    var dirs = Directory.GetDirectories(fullPath);

                    if (dirs.Length > 0)
                        items.AddRange(dirs.Select(dir => new DirectoryItem { FullPath = dir, Type = DirectoryItemType.Folder} ));
                }
                catch { }

            //Add files to the list
                try
                {
                    var fs = Directory.GetFiles(fullPath);

                    if (fs.Length > 0)
                        items.AddRange(fs.Select(files => new DirectoryItem { FullPath = files, Type = DirectoryItemType.File} ));
                }
                catch { }

            return items;
        }

        /// <summary>
            /// Find file OR folder name of the full path
            /// </summary>
            /// <param name="path"> The full path of the file/folder.</param>
            /// <returns></returns>
            public static string GetFileFolderName(string path)
        {
            //If path = empty, return empty 
            if (string.IsNullOrEmpty(path))
                return string.Empty;

            //Make all slashes backslashes
            var normalizedPath = path.Replace('/', '\\');

            // Find last backslash
            var lastIndex = normalizedPath.LastIndexOf('\\');

            if (lastIndex <= 0)
                return path;

            // Return the name after the last back slash
            return path.Substring(lastIndex + 1);
        }
    }
}
