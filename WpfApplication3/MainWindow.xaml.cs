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

namespace WpfApplication3
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

        private void BtnLogin_ClickEvent(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TxtUserName.Text) ||
                string.IsNullOrEmpty(PwdPassword.Password))
            {
                MessageBox.Text = "Username or Password cannot be empty";
                MessageBox.Foreground = new SolidColorBrush(Colors.Red);
            }
            else
            {
                if (TxtUserName.Text.Equals(PwdPassword.Password))
                {
                    MessageBox.Text = "Username or Password cannot be same";
                    MessageBox.Foreground = new SolidColorBrush(Colors.Red);
                }
                else
                {
                    MessageBox.Text = "Username and Password are valid entries";
                    MessageBox.Foreground = new SolidColorBrush(Colors.Green);
                }
            }
        }

        private void BtnCancel_ClickEvent(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
