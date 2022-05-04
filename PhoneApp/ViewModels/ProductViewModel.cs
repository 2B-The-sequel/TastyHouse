﻿using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.ViewModels
{
    public class ProductViewModel : ViewModel<Product>
    {
        private readonly Product product;

        public int Id { get; set; }
        public string Name { get { return product.Name; } set { product.Name = value; } }

        public double Price { get { return product.Price; } set { product.Price = value; } }

        public string Type { get { return product.Type; } set { product.Type = value; } }

        public ProductViewModel(Product model) : base(model)
        {
            this.product = model;
        }
    }
}
