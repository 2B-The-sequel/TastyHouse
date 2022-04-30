using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public ObservableCollection<ProductViewModel> Sides { get; set; }
        public ObservableCollection<MenuViewModel> Menus { get; set; }
        public ObservableCollection<ContentViewModel> Contents { get; set; }
        ContentRepo CR = new ContentRepo();


        public OrderViewModel SelectedOrder { get; set; }
        public ContentViewModel SelectedContent { get; set; }


        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Menus = new ObservableCollection<MenuViewModel>();
            Contents = new ObservableCollection<ContentViewModel>();

            Sides = new ObservableCollection<ProductViewModel> { };

            //TESTING
            for (int i = 1; i <= 10; i++)
            {
                Order order = new(i);
                OrderViewModel ovm = new(order);
                Orders.Add(ovm);
            }

            List<Content> contentList = CR.GetAll();
            foreach (Content content in contentList)
            {
                Contents.Add(new ContentViewModel (content));
            }
                
            
            
            
            
            //END
        }


        // ======================================================
        // CRUD: Create
        // ======================================================




    }
}