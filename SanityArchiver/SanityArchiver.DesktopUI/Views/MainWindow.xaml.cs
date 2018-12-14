using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using SanityArchiver.Application.Models;
using SanityArchiver.Application.Models.Data;
using SanityArchiver.DesktopUI.ViewModels;

namespace SanityArchiver.DesktopUI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            DataContext = new DirectoryStructureViewModel();

        }

        public void ArchiveWindow(object sender, RoutedEventArgs e)
        {
            var archiveWindow = new ArchiveWindow();
            archiveWindow.Show();
        }
    }
}
