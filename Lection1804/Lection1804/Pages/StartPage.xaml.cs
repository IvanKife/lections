using System.Windows;
using System.Windows.Controls;

namespace Lection1804.Pages
{
    /// <summary>
    /// Логика взаимодействия для StartPage.xaml
    /// </summary>
    public partial class StartPage : Page
    {
        public StartPage()
        {
            InitializeComponent();
        }

        private void OpenNewsButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new NewsPage());
        }

        private void OpenAboutButton_Click(object sender, RoutedEventArgs e)
        {
            App.CurrentFrame.Navigate(new AboutPage());
        }
    }
}
