using PhoneApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class CartPage : Page, INotifyPropertyChanged
    {
        private double price = 0.0;
        public double Price { get { return price; } set {price = value; NotifyPropertyChanged(nameof(Price)); } }

        public MainViewModel MVM;
        public CartPage()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
            MVM = MainViewModel.Instance;
        }

        private void RemoveItemButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;
            MVM.Cart.Remove(obj);
            Price = MVM.GetCartTotal();
            NotifyPropertyChanged("CartTotal");
        
        }

        private void CompleteOrderButton_Click(object sender, RoutedEventArgs e)
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Used to notify UI of changes in a property.
        /// </summary>
        // <param name="propertyName">Name of the property changed.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
