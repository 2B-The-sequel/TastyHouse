using PhoneApp.ViewModels;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace PhoneApp.Views
{
    /// <summary>
    /// Interaction logic for MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page, INotifyPropertyChanged
    {
        public MainViewModel MVM;
        public CartViewModel cartViewModel;
        public ProductViewModel PVM;

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