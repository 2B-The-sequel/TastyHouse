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
            Minute = DateTime.Now.Minute.ToString("00");
            InitializeComponent();
            DataContext = this;
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
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
    }
}