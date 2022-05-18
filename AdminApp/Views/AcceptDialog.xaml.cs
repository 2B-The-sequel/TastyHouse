using System;
using System.ComponentModel;
using System.Windows;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for AcceptDialog.xaml
    /// </summary>
    public partial class AcceptDialog : Window, INotifyPropertyChanged
    {
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

        public AcceptDialog()
        {
            Hour = DateTime.Now.Hour.ToString();
            Minute = DateTime.Now.Minute.ToString();
            InitializeComponent();
            DataContext = this;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            string datestring = Hour + ":" + Minute;
            if (OnlyDigits(datestring))
            {
                DialogResult = true;
            }
            else
            {
                MessageBox.Show("Input må kun være tal imellem \n 00 - 23 : 00 - 59", "Input fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        //Metode til at tjekke input for Leveringstid færdigt i AdminApp
        public static bool OnlyDigits(string s)
        {
            bool onlyDigits = true;

            try
            {
                int holder = int.Parse(s[0].ToString() + s[1].ToString());
                int holder2 = int.Parse(s[3].ToString() + s[4].ToString());

                if (holder >= 24 || holder2 > 59 || s.Length>5)
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