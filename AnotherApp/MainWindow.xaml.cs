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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AnotherApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //textBlock1.SetBinding(TextBlock.TextProperty,
            //    new Binding() { Source = textBox1, Path = new PropertyPath("Text") });

            //textBlock1.SetBinding(TextBlock.TextProperty,
            //    new Binding() { ElementName = "textBox1", Path = new PropertyPath("Text") });
        }
    }
}
