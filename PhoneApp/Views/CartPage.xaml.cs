using PhoneApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System.IO;

namespace PhoneApp.Views
{
    /// <summary>
    /// Interaction logic for BasketPage.xaml
    /// </summary>
    public partial class CartPage : Page
    {
        
        public CartPage()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            ProductViewModel pvm = (ProductViewModel)button.DataContext;
            MainViewModel.Instance.RemoveFromCart(pvm);
        }

        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            ContactInfoDialog Dialog = new();
            if (Dialog.ShowDialog() == true)
            {
                string datestring = Dialog.Hour + ":" + Dialog.Minute;
                
                MainViewModel.Instance.AcceptOrder((int)Dialog.delMethod,(int)Dialog.PayMethod, datestring);
            }
           
        }
    }
}