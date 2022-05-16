using FoodMenuUtility.Persistence;
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
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page, INotifyPropertyChanged
    {

        public MainViewModel MVM;
        public CartViewModel cartViewModel;
        public MenuPage()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
            MVM = MainViewModel.Instance;
        }


        private void AddBurgerToCartButton_Click(object sender, RoutedEventArgs e)
        {
           
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
            NotifyPropertyChanged("CartTotal");
        }

        private void AddSandwichToCartButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
            NotifyPropertyChanged("CartTotal");
        }

        private void AddSideToCartButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
            NotifyPropertyChanged("CartTotal");
        }

        private void AddRefreshmentToCartButton_Click(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            var obj = (ProductViewModel)button.DataContext;


            MVM.Cart.Add(obj);
            NotifyPropertyChanged("CartTotal");
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
