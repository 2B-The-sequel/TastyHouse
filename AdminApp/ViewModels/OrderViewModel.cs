using System;
using System.Collections.Generic;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class OrderViewModel : ViewModel<Order>
    {
        public List<Product> Products 
        { 
            get 
            { 
                return model.Products; 
            } 
            set 
            { 
                model.Products = value; 
            } 
        }
        
        public int Id 
        { 
            get
            {
                return model.Id;
            }
            set
            {
                model.Id = value;
            }
        }

        public string OrderTotal
        {
            get
            {
                double orderTotal = 0;
                double itemPrice;

                foreach (Product item in model.Products)
                {
                    itemPrice = item.Price;

                    orderTotal = itemPrice + orderTotal;
                }

                return orderTotal.ToString() + "Kr.";
            }
        }


        public string Image
        {
            get
            {
                return State switch
                {
                    OrderState.Accepted => "/Resources/Accept.png",
                    OrderState.Declined => "/Resources/Decline.png",
                    OrderState.Awaiting => "/Resources/Question.png",
                    OrderState.Done => "/Resources/Done.png",
                    _ => null,
                };
            }
        }

        public DateTime DoneTime
        {
            get
            {
                return model.DoneTime;
            }
            set
            {
                model.DoneTime = value;
            }
        }

        public OrderState State 
        { 
            get
            {
                return model.State;
            }
            set
            {
                model.State = value;
                NotifyPropertyChanged(nameof(State));
                NotifyPropertyChanged(nameof(Image));
            }
        }

        public string ProductsText
        {
            get
            {
                string products = string.Empty;

                for (int i = 0; i < model.Products.Count; i++)
                {
                    products += model.Products[i].Name + ((i == model.Products.Count - 1) ? string.Empty : ", ");
                }

                return products;
            }
        }

        public OrderViewModel(Order model) : base(model) { }
    }
}