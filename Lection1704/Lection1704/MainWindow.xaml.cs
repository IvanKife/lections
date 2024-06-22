using System.Reflection.Emit;
using System.Windows;
using System.Windows.Controls;

namespace Lection1704
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            StackPanel panel = new();
            Label label = new Label();
            for (int i = 1; i <= 10; i++)
            {
                label = new();
                label.Content = $"text {i}";
                panel.Children.Add(label);
            }
            button.Content = panel;
        }
    }
}