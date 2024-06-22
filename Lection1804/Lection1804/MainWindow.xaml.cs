using Lection1804.Pages;
using System.Windows;

namespace Lection1804
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            App.CurrentFrame = MainFrame;
            App.CurrentFrame.Navigate(new StartPage());
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            if (MainFrame.CanGoBack) // CanGoForward
                MainFrame.GoBack(); // GoForward();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            // Доступность
            // GoBackButton.IsEnabled = MainFrame.CanGoBack;

            // Видимость
            if (MainFrame.CanGoBack)
                GoBackButton.Visibility = Visibility.Visible;
            else
                GoBackButton.Visibility = Visibility.Collapsed;
        }
    }
}