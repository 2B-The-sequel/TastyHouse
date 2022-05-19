using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using FoodMenuUtility.Models;
using System.Text.RegularExpressions;

namespace PhoneApp.Views
{
    /// <summary>
    /// Interaction logic for ContactInfoDialog.xaml
    /// </summary>
    public partial class ContactInfoDialog : Window, INotifyPropertyChanged
    {
        public ContactInfoDialog()
        {
            InitializeComponent();
            DataContext = this;
           
        }

        private int _payMethod;

        public PaymentMethod PayMethod
        {
            get
            { 
                return (PaymentMethod)_payMethod; 
            }
            set 
            {
                _payMethod = (int)value;
                 NotifyPropertyChanged(nameof(_payMethod));   
            }
        }

        private int _delMethod;
        public DeliveryMethod delMethod
        {
            get
            {
                return (DeliveryMethod)_delMethod;
            }
            set
            {
                _delMethod = (int)value;
                NotifyPropertyChanged(nameof(_delMethod));
            }
        }

        private string _firstName;
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyPropertyChanged(nameof(FirstName));
            }
        }

        private string _lastName;
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyPropertyChanged(nameof(LastName));
            }
        }

        private string _adress;
        public string Adress
        {
            get
            {
                return _adress;
            }
            set
            {
                _adress = value;
                NotifyPropertyChanged(nameof(Adress));
            }
        }

        private string _zipCode;
        public string ZipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCode = value;
                NotifyPropertyChanged(nameof(ZipCode));
            }
        }

        private string _hour;
        public string Hour
        {
            get
            {
                return _hour;
            }
            set
            {
                _hour = value;
                NotifyPropertyChanged(nameof(Hour));
            }
        }

        private string _minute;
        public string Minute
        {
            get
            {
                return _minute;
            }
            set
            {
                _minute = value;
                NotifyPropertyChanged(nameof(Minute));
            }
        }

        private string _city;
        public string City
        {
            get
            {
                return _city;
            }
            set
            {
                _city = value;
                NotifyPropertyChanged(nameof(City));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

       

        private void ContactAcceptButton_Click(object sender, RoutedEventArgs e)
        {
            string datestring = Hour + ":" + Minute;
            if (OnlyDigits(datestring))
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Leveringstidspunkt må kun være tal imellem \n 00 - 23 : 00 - 59", "Input fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ContactDeclineButton_Click(object sender, RoutedEventArgs e)
        {
            
            DialogResult = false;
        }

        public static bool OnlyDigits(string s)
        {
            bool onlyDigits = true;

            try
            {
                int holder = int.Parse(s[0].ToString() + s[1].ToString());
                int holder2 = int.Parse(s[3].ToString() + s[4].ToString());

                if (holder >= 24 || holder2 > 59 || s.Length > 5)
                    onlyDigits = false;

                for (int i = 0; i < s.Length && onlyDigits; i++)
                {
                    if (!char.IsNumber(s[i]) && s[i] != ':')
                    {
                        onlyDigits = false;
                    }
                }
            }
            catch (Exception) { onlyDigits = false; }

            return onlyDigits;
        }
    }
}
