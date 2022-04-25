using System;
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

        private OrderState _state;
        public OrderState State 
        { 
            get
            {
                return _state;
            }
            set
            {
                _state = value;
                NotifyPropertyChanged(nameof(State));
            }
        }

        public OrderViewModel(Order model) : base(model)
        {
            State = OrderState.Awaiting;
        }
    }
}