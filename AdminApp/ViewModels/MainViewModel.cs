﻿using System.Collections.ObjectModel;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public ObservableCollection<SideViewModel> Sides { get; set; }

        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();

            Sides = new ObservableCollection<SideViewModel> { };

            //TESTING
            Order order = new(10);
            OrderViewModel ovm = new(order);

            Orders.Add(ovm);
            //END
        }
    }
}