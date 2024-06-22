using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace lection0406
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            // Point point = e.GetPosition(this);
            // Title = $"{point.X};{point.Y}";
        }

        private void Element_MouseMove(object sender, MouseEventArgs e)
        {
            //var element = (UIElement)sender;
            //Point point = e.GetPosition(element);
            //positionLabel.Content = $"{point.X};{point.Y}";
        }

        Point? dragtPoint1 = null;
        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            var element = (UIElement)(e.Source);
            dragtPoint1 = e.GetPosition(canvas);
            element.CaptureMouse();
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragtPoint1 == null)
                return;

            var element = (UIElement)(e.Source);
            element.Focusable = true;
            var dragPoint2 = e.GetPosition(canvas);

            Canvas.SetLeft(element, dragPoint2.X - element.RenderSize.Width / 2);
            Canvas.SetTop(element, dragPoint2.Y - element.RenderSize.Height / 2);
        }

        private void Canvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var element = (UIElement)(e.Source);
            dragtPoint1 = null;
            element.ReleaseMouseCapture();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //this.DragMove();
        }

    }
}

/* Drag-n-Drop
 * DragEnter / PDE
 * DragOver / PDO
 * DragLeave / PDL
 * Drop / PD
 * 
 * 1. Создать источник перетаскивания. Создать в нём обработчик события, вызывающий перетаскивание
 * Например, MouseMove или MouseDown
 * 
 * 2. Вызвать метод DoDragDrop в обработчике-источнике
 * var element = sender as Label;
 * DragDrop.DoDragDrop(element, element.Content, DragDropEffects.Copy);
 * 
 * Виды DragDropEffects:
 * 1) Copy - копирование данных из источника
 * 2) All - данные копируются из источника и удаляются из него
 * 3) Link - данные источника связываются с данными приёмника
 * 4) None - целевой объект не принимает данные
 * 5) Scroll - данные источника прокручиваются при копировании приёмника
 * 
 * 3. В целевом элементе или приёмника разрешить перетаскивание
 * AllowDrop = "True"
 * И создать обработчик события Drop
 * Пример:
 * var destination = sender as TextBlock;
 * destination.Text = e.Data.ToString();
 * Или
 * destination.Text = e.Data.GetData(DataFormats.Text).ToString();
 * Data - буфер обмена, DataFormats - формат доступные для перетаскивания
 * 
 * Перетаскивание данных из одного элемента в другой
 */
