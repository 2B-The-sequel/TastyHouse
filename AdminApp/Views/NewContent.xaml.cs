using AdminApp.ViewModels;
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

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for NewContent.xaml
    /// </summary>
    public partial class NewContent : Window
    {
        MainViewModel MVM;
        public string name { get; set; }
        public double price { get; set; }
        public byte[] image { get; set; }
        public NewContent()
        {
            
            InitializeComponent();
            DataContext = this;
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
