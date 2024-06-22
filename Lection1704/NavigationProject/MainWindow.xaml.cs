using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Resources;
using System.Windows.Shapes;
using NavigationProject.Pages;

namespace NavigationProject
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
            App.CurrentFrame.Navigate(new MenuPage());

            var imagePath1 = new Uri(@"C:\Temp\ispp21\Images\plant.png");
            var bitmapImage1 = new BitmapImage(imagePath1);
            image1.Source = bitmapImage1;

            //var imagePath2 = new Uri(@"Images\plant.png", UriKind.RelativeOrAbsolute);
            //var bitmapImage2 = new BitmapImage(imagePath2);
            //image1.Source = bitmapImage2;

            rectangle.Fill = new ImageBrush(bitmapImage1);
            ellipse.Fill = new ImageBrush(bitmapImage1);

            // Виды кистей
            SolidColorBrush solidColorBrush = new(Colors.Lime);
            Background = solidColorBrush;

            var cursorUri = new Uri(@"working.ani", UriKind.Relative);
            StreamResourceInfo stream = Application.GetResourceStream(cursorUri);
            Cursor = new(stream.Stream);

        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.GoBack();
        }

        private void MainFrame_ContentRendered(object sender, EventArgs e)
        {
            //BackButton.IsEnabled = MainFrame.CanGoBack; //CanGoForward
            if (MainFrame.CanGoBack)
                BackButton.Visibility = Visibility.Visible;
            else
                BackButton.Visibility = Visibility.Hidden;

        }

        private void MainFrame_Navigated(object sender, NavigationEventArgs e)
        {

        }
    }
}