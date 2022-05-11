using PhoneApp.ViewModels;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhoneApp.Views
{
    /// <summary>
    /// Interaction logic for BasketPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
      
        public MainViewModel MVM;
        public CartPage()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
            MVM = MainViewModel.Instance;
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
