using System;
using System.Windows;
using System.Windows.Controls;
using SanityArchiver.Application.Models.Data;

namespace SanityArchiver.DesktopUI.ViewModels
{
    public class MyTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement elem = container as FrameworkElement;
            if (elem == null)
            {
                return null;
            }

            if (item == null || !(item is DirectoryItemVievModel))
            {
                throw new ApplicationException();
            }

            if ((item as DirectoryItemVievModel).Type == DirectoryItemType.Folder)
            {
                return elem.FindResource("FolderDataTemplate") as DataTemplate;
            }

            if ((item as DirectoryItemVievModel).Type == DirectoryItemType.File)
            {
                return elem.FindResource("FileDataTemplate") as DataTemplate;
            }
            
            if ((item as DirectoryItemVievModel).Type == DirectoryItemType.Drive)
            {
                return elem.FindResource("DriveDataTemplate") as DataTemplate;
            }

            throw new ApplicationException();
        }
    }
}