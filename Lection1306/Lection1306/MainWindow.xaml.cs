using System.Windows;
using System.Windows.Media;

namespace Lection1306
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string data = "example";
            User user = new() { Login = "admin", Password = "qwerty" };
            var date = DateTime.Now;

            //dataTextBox.DataContext = data;
            //loginTextBox.DataContext = user;

            DataContext = user;

            //passwordTextBox.DataContext = user;

            login2TextBox.DataContext = user.Login;

            List<User> users = new()
            {
                user,
                new() { Login = "manager", Password = "123" },
                new() { Login = "customer", Password = "456" }
            };
            userListView.ItemsSource = users;
        }

        private void Window_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            panel.Background = new SolidColorBrush(Colors.Orange);
        }
    }
}