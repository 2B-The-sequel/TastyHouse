using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;
using System;
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
                double cartTotal = 0;
                double itemPrice;

                foreach (ProductViewModel item in Cart)
                {
                    itemPrice = item.Price;

                    cartTotal = itemPrice + cartTotal;
                }

                return cartTotal; 
            }
        }

        public AccountViewModel AVM { get; set; }

        private DeliveryMethod _selectedDeliveryMethod = DeliveryMethod.Delivery;
        public DeliveryMethod SelectedDeliveryMethod 
        {
            get
            {
                return _selectedDeliveryMethod;
            }
            set
            {
                _selectedDeliveryMethod = value;
            }
        }

        // Singleton
        private static MainViewModel s_instance;
        public static MainViewModel Instance
        {
            get
            {
                if (s_instance == null)
                    s_instance = new MainViewModel();
                return s_instance;
            }
        }

        public void AcceptOrder()
        {
            //Sætter date til tidspunkt "Gennemfør bestilling")
            DateTime DateOfOrder = DateTime.Now;
            List<int> intlist = new();
            foreach (ProductViewModel product in Cart)
            { intlist.Add(product.Id); }

            int idnumber =  OrderRepo.Instance.Create(DateOfOrder,intlist).Id;
            //Slet indholder i Cart når ordren er lavet
            Cart.Clear();
            NotifyPropertyChanged(nameof(CartTotal));
        }

        private MainViewModel()
        {
            Burgers = new ObservableCollection<ProductViewModel>();
            Sandwiches = new ObservableCollection<ProductViewModel>();
            Sides = new ObservableCollection<ProductViewModel>();
            Refreshments = new ObservableCollection<ProductViewModel>();
            Cart = new ObservableCollection<ProductViewModel>();

            AVM = new(new Account("will@smith.dk", "12345", 88888888, "Will", "Smith", "Viljesmedvej 20", 5000, "Odense"));

            List<Product> burgerList = ProductRepo.Instance.RetrieveAll();
            foreach (Product product in burgerList)
            {
                if (product.ProductType.ToString() == "Burger")
                {
                    Burgers.Add(new ProductViewModel(product));
                }
            }

            List<Product> sandwichList = ProductRepo.Instance.RetrieveAll();
            foreach (Product product in sandwichList)
            {
                if (product.ProductType.ToString() == "Sandwich")
                {
                    Sandwiches.Add(new ProductViewModel(product));
                }
            }

            List<Product> sidesList = ProductRepo.Instance.RetrieveAll();
            foreach (Product product in sidesList)
            {
                if (product.ProductType.ToString() == "Side")
                {
                    Sides.Add(new ProductViewModel(product));
                }
            }

            List<Product> refreshmentsList = ProductRepo.Instance.RetrieveAll();
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
            NotifyPropertyChanged(nameof(CartTotal));
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