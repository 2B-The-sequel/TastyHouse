using PhoneApp.ViewModels;
using System.Windows;
using System.Windows.Controls;
using System;

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

            Dialog.FirstName = MainViewModel.Instance.AVM.FirstName;
            Dialog.LastName = MainViewModel.Instance.AVM.LastName;
            Dialog.Address = MainViewModel.Instance.AVM.Address;
            Dialog.ZipCode = MainViewModel.Instance.AVM.ZipCode.ToString();
            Dialog.City = MainViewModel.Instance.AVM.City;
            Dialog.DelMethod = MainViewModel.Instance.SelectedDeliveryMethod;

            if (Dialog.ShowDialog() == true)
            {
                MainViewModel.Instance.AcceptOrder(Dialog.DelMethod, Dialog.PayMethod, DateTime.ParseExact(Dialog.Hour + ":" + Dialog.Minute, "HH:mm", null));
            }
        }
    }
}