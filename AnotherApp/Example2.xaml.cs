using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;

namespace AnotherApp
{
    /// <summary>
    /// Interaction logic for Example2.xaml
    /// </summary>
    public partial class Example2 : Window
    {
        public Example2()
        {
            InitializeComponent();

            //textBlock1.SetBinding(TextBlock.TextProperty,
            //    new Binding() { Source = slider1, Path = new PropertyPath("Value"), StringFormat="##" });

            var converter = new SliderToTextBlockForegroundBrushConverter();

            //textBlock1.SetBinding(TextBlock.ForegroundProperty,
            //    new Binding { Source = slider1, Path = new PropertyPath("Value"), Converter = converter });
        }
    }

    public class SliderToTextBlockForegroundBrushConverter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var tax = (double)value;
            if (tax != 30 && tax > 30) return Brushes.Red;
            else return Brushes.Green;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
