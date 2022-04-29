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
        public NewContent()
        {
            
            InitializeComponent();
            MVM = new MainViewModel();
            DataContext = MVM;
        }

        private void AddNewContent(object sender, RoutedEventArgs e)
        {
            string Name = ContentName.Text;
            double exstraPrice = Convert.ToDouble(ExstraPrice.Text);
            MVM.AddContent(Name, exstraPrice);
        }
        private void Cancel(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
