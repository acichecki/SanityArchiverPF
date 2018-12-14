using System.Windows;
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
            var archiveViewModel = new ArchiveViewModel(DirectoryStructureViewModel.Selected);
            archiveWindow.DataContext = archiveViewModel;
            archiveWindow.Show();

        }
    }
    
}
