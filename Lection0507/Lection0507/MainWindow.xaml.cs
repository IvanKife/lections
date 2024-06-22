using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lection0507
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Button clearButton = new Button();
            clearButton.Content = "Clear";
            clearButton.Click += ClearButton_Click;
            panel.Children.Add(clearButton);
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(e.RoutedEvent.Name);

            // e.Source
            var button = (Button)e.Source;
            numberTextBox.Text += button.Content;
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}