using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace PhoneApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ProductViewModel> Burgers { get; set; }
        public ObservableCollection<ProductViewModel> Sandwiches { get; set; }
        public ObservableCollection<ProductViewModel> Sides { get; set; }
        public ObservableCollection<ProductViewModel> Refreshments { get; set; }
        public ObservableCollection<ProductViewModel> Cart { get; set; }

        public double CartTotal
        {
            get 
            { 
                return GetCartTotal(); 
            }
        }

        //MenuRepo mr = new MenuRepo();
        ProductRepo pr = new ProductRepo();

        public AccountViewModel AVM { get; set; }

        // Singleton
        private static MainViewModel _instance;
        public static MainViewModel Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new MainViewModel();
                return _instance;
            }
        }

        public double GetCartTotal()
        {
            double CartTotal = 0;
            double itemPrice;

            foreach (ProductViewModel item in Cart)
            {
                itemPrice = item.Price;

                CartTotal = itemPrice + CartTotal;
            }

            return CartTotal;
           
        }

        private MainViewModel()
        {
            Burgers = new ObservableCollection<ProductViewModel>();
            Sandwiches = new ObservableCollection<ProductViewModel>();
            Sides = new ObservableCollection<ProductViewModel>();
            Refreshments = new ObservableCollection<ProductViewModel>();
            Cart = new ObservableCollection<ProductViewModel>();

            AVM = new(new Account("will@smith.dk", "12345", 88888888, "Will", "Smith", "Viljesmedvej 20", 5000, "Odense"));

            List<Product> burgerList = pr.GetAll();
            foreach (Product product in burgerList)
            {
                if (product.ProductType.ToString() == "Burger")
                {
                    Burgers.Add(new ProductViewModel(product));
                }
            }

            List<Product> sandwichList = pr.GetAll();
            foreach (Product product in sandwichList)
            {
                if (product.ProductType.ToString() == "Sandwich")
                {
                    Sandwiches.Add(new ProductViewModel(product));
                }
            }

            List<Product> sidesList = pr.GetAll();
            foreach (Product product in sidesList)
            {
                if (product.ProductType.ToString() == "Side")
                {
                    Sides.Add(new ProductViewModel(product));
                }
            }

            List<Product> refreshmentsList = pr.GetAll();
            foreach (Product product in refreshmentsList)
            {
                if (product.ProductType.ToString() == "Refreshment")
                {
                    Refreshments.Add(new ProductViewModel(product));
                }
            }
        }

        public void RemoveFromCart(ProductViewModel cvm)
        {
            Cart.Remove(cvm);
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