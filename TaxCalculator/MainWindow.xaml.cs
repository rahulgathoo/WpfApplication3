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

namespace TaxCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SalaryCalculator calculator;

        public MainWindow()
        {
            InitializeComponent();
            calculator = (SalaryCalculator)this.Resources["calculator"];
        }

        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            calculator.CalcSalary();
        }
    }

    public class CalCulateEnableConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var hasBasic = !string.IsNullOrEmpty((string)values[0]);
            var hasHRA = !string.IsNullOrEmpty((string)values[1]);
            var hasDA = !string.IsNullOrEmpty((string)values[2]);
            var isCalcEnable = hasBasic && hasHRA && hasDA;

            return isCalcEnable;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class SalaryCalculator: INotifyPropertyChanged
    {
        private double basic;
        private double hra;
        private double da;
        private double tax;
        private double salary;
        private bool isSalaryCalculatable;

        public double Basic
        {
            get { return basic; }
            set 
            {
                basic = value;
                SetProperty("Basic");
                CheckSalaryIsCalculatable();
            }
        }

        public double HRA
        {
            get { return hra; }
            set
            {
                hra = value;
                SetProperty("HRA");
                CheckSalaryIsCalculatable();
            }
        }
        
        public double DA
        {
            get { return da; }
            set
            {
                da = value;
                SetProperty("DA");
                CheckSalaryIsCalculatable();
            }
        }
        
        public double TAX
        {
            get { return tax; }
            set
            {
                tax = value;
                SetProperty("TAX");
            }
        }

        public double Salary
        {
            get { return salary; }
            private set
            {
                salary = value;
                SetProperty("Salary");
            }
        }

        public void CalcSalary()
        {
            var net = basic + hra + da;
            var taxable = net * (tax / 100);
            Salary = net - taxable;
        }

        public bool IsSalaryCalculatable
        {
            get { return isSalaryCalculatable; }

            private set
            {
                isSalaryCalculatable = value;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void SetProperty(string propName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
        }

        private void CheckSalaryIsCalculatable()
        {
            if (basic > 0 && hra > 0 && da > 0)
                IsSalaryCalculatable = true;
            else
                IsSalaryCalculatable = false;
        }
    }
}
