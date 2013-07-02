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
using System.ComponentModel;
using System.Diagnostics;


namespace COntrol2ObjectBinding
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

        private void BtnBindData_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnPrintObjState_Click(object sender, RoutedEventArgs e)
        {
            var emp = (Employee)LayoutRoot.Resources["emp"];
            Debug.WriteLine(emp);
        }

        private void BtnChangeObjState_Click(object sender, RoutedEventArgs e)
        {
            var emp = (Employee)LayoutRoot.Resources["emp"];
            emp.Firstname = "Chinmay";
            emp.Lastname = "Dude";
            Debug.WriteLine(emp);
        }
    }

    public class Employee: INotifyPropertyChanged
    {
        private string _firstName;
        private string _lastName;

        public string Firstname
        {
            get { return _firstName; }
            set
            {
                _firstName = value;
                SetPropertyValue("Firstname");
            }
        }
        public string Lastname
        {
            get { return _lastName; }
            set
            {
                _lastName = value;
                SetPropertyValue("Lastname");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetPropertyValue(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
