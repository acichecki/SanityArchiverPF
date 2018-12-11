using SanityArchiver.Application.Models;
using SanityArchiver.Application.Models.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SanityArchiver.DesktopUI.ViewModels
{
    /// <summary>
    /// View model for each directory item
    /// </summary>
    public class DirectoryItemVievModel : BaseViewModel
    {
        #region Public Properties
        // Type of this item
        public DirectoryItemType Type { get; set; }

        //Full path to the item
        public string FullPath { get; set; }

        public string Name { get { return this.Type == DirectoryItemType.Drive ? FullPath : DirectoryStructure.GetFileFolderName(this.FullPath); } }


        /// <summary>
        /// List of all children contained INSIDE this item
        /// </summary>
        public ObservableCollection<DirectoryItemVievModel> Children { get; set; }

        /// <summary>
        /// Item can be expanded if it`s not a file type. 
        /// </summary>
        public bool CanExpand { get { return this.Type != DirectoryItemType.File;} }


        public bool IsExpanded
        {
            get
            {
                return this.Children?.Count(f => f != null) > 0;
            }
            set
            {
                // If UI tells to expand
                if (value == true)
                    //Find all children
                    Expand();
                else
                    this.ClearChildren();
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        public DirectoryItemVievModel(string fullPath, DirectoryItemType type)
        {
            this.ExpandCommand = new RelayCommand(Expand);

            this.FullPath = fullPath;
            this.Type = type;

            // Setup chilldren
            this.ClearChildren();
        }
        #endregion

        #region Public Commands

        /// <summary>
        /// Command that expand this item
        /// </summary>
        public ICommand ExpandCommand { get; set; }
        #endregion

        #region Helper Method
        /// <summary>
        /// Removes all chilldren from the list, and add NULL -> Add expand arrow, by adding dummy item
        /// </summary>
        private void ClearChildren()
        {
            //Clear items
            this.Children = new ObservableCollection<DirectoryItemVievModel>();

            //Show expand arrows if this is not a FILE
            if (this.Type != DirectoryItemType.File)
                this.Children.Add(null);                            
        }

        /// <summary>
        /// Expand this directory and finds all chlidren
        /// </summary>

        #endregion

        private void Expand()
        {
            //Cannot expand a file
            if (this.Type == DirectoryItemType.File)
                return;
            //Find all children
            var children = DirectoryStructure.GetDirectoryContents(this.FullPath);
            this.Children = new ObservableCollection<DirectoryItemVievModel>(
               children.Select(content => new DirectoryItemVievModel(content.FullPath, content.Type)));
        }
    }
}
