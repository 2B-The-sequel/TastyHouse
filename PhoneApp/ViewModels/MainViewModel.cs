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
        public ObservableCollection<MenuViewModel> Menus { get; set; }
        public ObservableCollection<ProductViewModel> Burgers { get; set; }
        public ObservableCollection<ProductViewModel> Sandwiches { get; set; }
        public ObservableCollection<ProductViewModel> Sides { get; set; }
        public ObservableCollection<ProductViewModel> Refreshments { get; set; }
       
        MenuRepo mr = new MenuRepo();
        ProductRepo pr = new ProductRepo();

        public MainViewModel()
        {
            Menus = new ObservableCollection<MenuViewModel>();
            Burgers = new ObservableCollection<ProductViewModel>();
            Sandwiches = new ObservableCollection<ProductViewModel>();
            Sides = new ObservableCollection<ProductViewModel>();
            Refreshments = new ObservableCollection<ProductViewModel>();
           
            List<Menu> menuList = mr.GetAll();
            foreach (Menu menu in menuList)
            {
                Menus.Add(new MenuViewModel(menu));
            }

            List<Product> burgerList = pr.GetAll();
            foreach (Product product in burgerList)
            {
                if (product.Type == "Burger")
                {
                    Burgers.Add(new ProductViewModel(product));
                }
            }

            List<Product> sandwichList = pr.GetAll();
            foreach (Product product in sandwichList)
            {
                if (product.Type == "Sandwich")
                {
                    Sandwiches.Add(new ProductViewModel(product));
                }
            }

            List<Product> sidesList = pr.GetAll();
            foreach (Product product in sidesList)
            {
                if (product.Type == "Side")
                {
                    Sides.Add(new ProductViewModel(product));
                }
            }

            List<Product> refreshmentsList = pr.GetAll();
            foreach (Product product in refreshmentsList)
            {
                if (product.Type == "Refreshment")
                {
                    Refreshments.Add(new ProductViewModel(product))
                }
            }

        }

        

}
}