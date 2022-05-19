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


        private string _firstName;
        public string firstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                NotifyPropertyChanged(nameof(firstName));
            }
        }

        private string _lastName;
        public string lastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                NotifyPropertyChanged(nameof(lastName));
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
        public string zipCode
        {
            get
            {
                return _zipCode;
            }
            set
            {
                _zipCude = value;
                NotifyPropertyChanged(nameof(zipCode));
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
            DialogResult = true;
        }

        private void ContactDeclineButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
