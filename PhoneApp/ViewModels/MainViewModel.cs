using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodMenuUtility.Persistence;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<ProductViewModel> Burgers { get; set; }
        public ObservableCollection<ProductViewModel> Sandwiches { get; set; }
        public ObservableCollection<ProductViewModel> Sides { get; set; }
        public ObservableCollection<ProductViewModel> Refreshments { get; set; }
        public ObservableCollection<ProductViewModel> Cart { get; set; }
       
        //MenuRepo mr = new MenuRepo();
        ProductRepo pr = new ProductRepo();

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

        private MainViewModel()
        {
            
            Burgers = new ObservableCollection<ProductViewModel>();
            Sandwiches = new ObservableCollection<ProductViewModel>();
            Sides = new ObservableCollection<ProductViewModel>();
            Refreshments = new ObservableCollection<ProductViewModel>();
            Cart = new ObservableCollection<ProductViewModel>();
           
            /*List<Menu> menuList = mr.GetAll();
            foreach (Menu menu in menuList)
            {
                Menus.Add(new MenuViewModel(menu));
            }
            */
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

        

}
}