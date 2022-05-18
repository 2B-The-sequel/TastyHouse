using System;
using System.Collections.Generic;

namespace FoodMenuUtility.Models
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        private byte[] image = Array.Empty<byte>();
        public byte[] Image 
        { 
            get
            {
                return image;
            }
            set
            {
                image = value;
            }
        }

        public List<Ingredient> Ingredients { get; set; }

        public ProductType ProductType { get; set; }

        public Product(int id, string name, double price, ProductType type, byte[] image)
        {
            Id = id;
            Name = name;
            Price = price;
            ProductType = type;
            Image = image;

            Ingredients = new List<Ingredient>();
        }
    }
}