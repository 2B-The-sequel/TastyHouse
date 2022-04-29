using System;

namespace FoodMenuUtility.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime DoneTime { get; set; }

        public OrderState State { get; set; }

        public Order(int Id)
        {
            this.Id = Id;
            State = OrderState.Awaiting;
        }
    }
}