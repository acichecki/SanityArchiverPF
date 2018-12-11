using SanityArchiver.Application.Models;
using SanityArchiver.Application.Models.Data;
using SanityArchiver.DesktopUI.Views;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace SanityArchiver.DesktopUI
{ 
    /// <summary>
    /// Convert full path to specyfic image type of drive, folder or file
    /// </summary>

    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImage : IValueConverter
    {
        public static HeaderToImage Instance = new HeaderToImage();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

           
            //By default file image
            var image = "Images/file.png";

            switch ((DirectoryItemType)value)
            {
                case DirectoryItemType.Drive:
                    image = "Images/drive.png";
                    break;

                case DirectoryItemType.Folder:
                    image = "Images/folder-closed.png";
                    break;


            }
                
            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
