using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class OrderViewModel
    {
        private readonly Order order;

        public int Id 
        { 
            get
            {
                return order.Id;
            }
            set
            {
                order.Id = value;
            }
        }

        public OrderViewModel(Order order)
        {
            this.order = order;
        }
    }
}