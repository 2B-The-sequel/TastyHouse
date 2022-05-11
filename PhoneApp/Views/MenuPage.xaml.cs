using FoodMenuUtility.Persistence;
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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MainViewModel MVM;
        public CartViewModel cartViewModel;
        public MenuPage()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
            MVM = MainViewModel.Instance;
        }


        private void AddToCartButton_Click(object sender, RoutedEventArgs e)
        {
           
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
        }

        private void AddToCartButton1_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
        }

        private void AddToCartButton2_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
        }

        private void AddToCartButton3_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
        }
    }
}
