using System.Security.Cryptography.X509Certificates;
using System.Windows;

namespace SanityArchiver.DesktopUI.Views
{
    public partial class ArchiveWindow : Window
    {
        public ArchiveWindow()
        {
            InitializeComponent();
        }

        private void Close_Button(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
