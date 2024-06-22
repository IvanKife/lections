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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            listBox1.Items.Add("asd");
            listBox1.Items.Add("qwe");
            listBox1.Items.Add("zxc");
            listBox1.Items.Add("12345");
            listBox1.Items.Add("789");
        }

        private void label1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var source = sender as Label;
            DragDrop.DoDragDrop(source, source.Content, DragDropEffects.Copy);
        }

        private void label2_Drop(object sender, DragEventArgs e)
        {
            var destination = sender as Label;
            destination.Content = e.Data.GetData(DataFormats.Text);
        }

        private void ListBox2_Drop(object sender, DragEventArgs e)
        {
            listBox2.Items.Add(e.Data.GetData(DataFormats.Text));
        }

        private void ListBox1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DragDrop.DoDragDrop(listBox1, listBox1.SelectedItem, DragDropEffects.Copy);
            //listBox1.Items.Remove(listBox1.SelectedItem);
        }
    }
}