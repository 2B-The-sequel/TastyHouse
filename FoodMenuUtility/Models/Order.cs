using System;
using System.Collections.Generic;

namespace FoodMenuUtility.Models
{
    public class Order
    {
        public int Id { get; set; }

        public DateTime DoneTime { get; set; }

        public DateTime Date { get; set; }

        public OrderState State { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        public DeliveryMethod DeliveryMethod { get; set; }

        public List<Product> Products { get; set; }

        public Order(int Id, DateTime Date, DateTime DoneTime, int state,int payMethod, int delMethod)
        {
            this.Id = Id;
            this.Date = Date;
            this.DoneTime = DoneTime;
            this.State = (OrderState)state;
            this.PaymentMethod = (PaymentMethod)payMethod;
            this.DeliveryMethod = (DeliveryMethod)delMethod;
            Products = new List<Product>();
        }
        public Order(DateTime Date, DateTime DoneTime, int state, int payMethod, int delMethod)
        {
            this.Id = Id;
            this.Date = Date;
            this.DoneTime = DoneTime;
            this.State = (OrderState)state;
            this.PaymentMethod = (PaymentMethod)payMethod;
            this.DeliveryMethod = (DeliveryMethod)delMethod;
            Products = new List<Product>();
        }

        public Order(int Id, DateTime Date, DateTime DoneTime)
        {
            this.Id = Id;
            this.Date = Date;
            this.DoneTime = DoneTime;
            State = OrderState.Awaiting;
            Products = new List<Product>();
        }

        public Order(int Id, DateTime Date)
        {
            this.Id = Id;
            this.Date = Date;
            State = OrderState.Awaiting;
            Products = new List<Product>();
        }
    }
}