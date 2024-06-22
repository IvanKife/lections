using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace Lection1306
{
    public class User
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public int Salary { get; set; } = 25000;
        public DateTime Birthday { get; set; } = DateTime.Now;

        public string UserSalary { get => $"{Salary:0.00} руб."; }
    }

    public class SalaryConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return $"{(int)value:0.00} руб.";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
        }
    }
}
