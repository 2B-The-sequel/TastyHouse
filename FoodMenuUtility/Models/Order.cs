using System;
using System.Collections.Generic;

namespace FoodMenuUtility.Models
{
    public class Order
    {

        public List<Product> products { get; set; }
        public int Id { get; set; }

        public DateTime DoneTime { get; set; }

        public DateTime Date { get; set; }

        public OrderState State { get; set; }

        public Order(int Id)
        {
            this.Id = Id;
            State = OrderState.Awaiting;
            products = new List<Product>();

        }

        public Order(int id, DateTime Date)
        {
            this.Id = id;
            this.Date = Date;
            State = OrderState.Awaiting;
            products = new List<Product>();
        }

        public Order(int Id, DateTime Date, DateTime DoneTime)
        {
            this.Id = Id;
            this.Date = Date;
            this.DoneTime = DoneTime;
            products = new List<Product>();
        }

        public Order(DateTime Date)
        { this.Date = Date;
        products = new List<Product>();
        }
    }
}