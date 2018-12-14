using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanityArchiver.Application.Models.Data
{
    /// <summary>
    /// The type od directory item
    /// </summary>
    public enum DirectoryItemType
    {

        //Logical DRIVE
        Drive,
        //Physical FILE
        File,
        //A folder
        Folder
    }
}
