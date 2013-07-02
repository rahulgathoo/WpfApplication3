using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AnotherApp
{
    /// <summary>
    /// Interaction logic for ColorChooser.xaml
    /// </summary>
    public partial class ColorChooser : Window
    {
        public ColorChooser()
        {
            InitializeComponent();
        }
    }

    public class SliderValueToColorConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var alpha = System.Convert.ToByte(values[0]);
            var red = System.Convert.ToByte(values[1]);
            var green = System.Convert.ToByte(values[2]);
            var blue = System.Convert.ToByte(values[3]);
            var color = new Color { A = alpha, R = red, G = green, B = blue };

            return new SolidColorBrush(color);
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
