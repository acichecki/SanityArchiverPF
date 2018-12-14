using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows.Input;
using SanityArchiver.Application.Models;
using SanityArchiver.Application.Models.Data;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// View model for each directory item
    /// </summary>
    public class DirectoryItemVievModel : BaseViewModel
    {
        bool isSelected;
        // Type of this item
        public DirectoryItemType Type { get; set; }

        //Full path to the item
        public string FullPath { get; set; }

        public string Name { get { return Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(FullPath); } }

        public string ImageName => Type == DirectoryItemType.Drive ? "drive" : (Type == DirectoryItemType.File ? "file" : (IsExpanded ? "folder-open" : "folder-closed"));
        
        public DateTime CreationDate => Type == DirectoryItemType.File ? new FileInfo(FullPath).CreationTime : DateTime.Now;

        public double Size => Type == DirectoryItemType.File ? LongToDouble(new FileInfo(FullPath).Length, BytesToMegabytes(new FileInfo(FullPath).Length), 2) : 0;

        /// <summary>
        /// List of all children contained INSIDE this item
        /// </summary>
        public ObservableCollection<DirectoryItemVievModel> Children { get; set; }

        /// <summary>
        /// Item can be expanded if it`s not a file type. 
        /// </summary>
        //public bool CanExpand { get { return Type != DirectoryItemType.File;} }

        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value; }
        }
        
        public bool IsExpanded
        {
            get
            {
                return Children?.Count(f => f != null) > 0;
            }
            set
            {
                // If UI tells to expand
                if (value)
                    //Find all children
                    Expand();
                else
                    ClearChildren();
            }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryItemVievModel(string fullPath, DirectoryItemType type)
        {
            ExpandCommand = new RelayCommand(Expand);

            FullPath = fullPath;
            Type = type;

            // Setup chilldren
            ClearChildren();
        }

        /// <summary>
        /// Command that expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }

        /// <summary>
        /// Removes all chilldren from the list, and add NULL -> Add expand arrow, by adding dummy item
        /// </summary>
        private void ClearChildren()
        {
            //Clear items
            Children = new ObservableCollection<DirectoryItemVievModel>();

            //Show expand arrows if this is not a FILE
            if (Type != DirectoryItemType.File)
                Children.Add(null);                            
        }

        /// <summary>
        /// Expand this directory and finds all chlidren
        /// </summary>
        private void Expand()
        {
            //Cannot expand a file
            if (Type == DirectoryItemType.File)
                return;
            //Find all children
            var children = DirectoryStructure.GetDirectoryContents(FullPath);

            if (children != null)
            {
                Children = new ObservableCollection<DirectoryItemVievModel>(
                    children.Select(content => new DirectoryItemVievModel(content.FullPath, content.Type)));
            }
            
        }

        private long BytesToMegabytes(long number)
        {
            return Convert.ToInt32(Math.Floor(Math.Log(number, 1024)));
        }

        private double LongToDouble(long numberInBytes, long numberInMb, int decimalPlaces)
        {
            return Math.Round(numberInBytes / Math.Pow(1024, numberInMb), decimalPlaces);
        }
    }
}
