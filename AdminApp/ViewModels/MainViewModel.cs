using System.Collections.ObjectModel;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<MenuViewModel> Menus { get; set; }
        public ObservableCollection<ContentViewModel> Contents { get; set; }


        public OrderViewModel SelectedOrder { get; set; }



        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Menus = new ObservableCollection<MenuViewModel>();
            Contents = new ObservableCollection<ContentViewModel>();

            //TESTING
            for (int i = 1; i <= 10; i++)
            {
                Order order = new(i);
                OrderViewModel ovm = new(order);
                Orders.Add(ovm);
            }
            //END
        }
    }
}