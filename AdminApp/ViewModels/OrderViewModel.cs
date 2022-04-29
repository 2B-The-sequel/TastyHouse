﻿using System;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class OrderViewModel : ViewModel<Order>
    {
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

        public OrderViewModel(Order model) : base(model) { }
    }
}