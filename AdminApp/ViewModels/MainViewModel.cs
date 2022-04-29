using System.Collections.ObjectModel;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<MenuViewModel> Menus { get; set; }
        public ObservableCollection<ContentViewModel> Contents { get; set; }
        //ContentRepo CR = new ContentRepo();


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
            for (int i = 0; i < 5; i++)
            {
                int pingy = i;
                string x = "Indhold " + i;
                double y = i*i;
                Content content = new(pingy, x, y);
                ContentViewModel cvm = new(content);
                Contents.Add(cvm);
            }
            
            //END
        }


        // ======================================================
        // CRUD: Create
        // ======================================================


        public void AddContent(string name, double extraPrice)
        {

            
            
        }


    }
}