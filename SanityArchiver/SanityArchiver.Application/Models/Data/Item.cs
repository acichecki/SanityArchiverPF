using System;
using System.IO;


namespace SanityArchiver.Application.Models.Data
{
    public abstract class Item
    {
        public DirectoryItemType Type { get; set; }
    }
}
