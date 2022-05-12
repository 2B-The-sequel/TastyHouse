
using FoodMenuUtility.Models;
using System.Collections.Generic;

namespace FoodMenuUtility.Models
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }  

        public byte[] Image { get; set; }
        public int Id { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        private ProductType productType;

        public ProductType ProductType
        {
            get { return productType; }
            set { productType = value; }
        }


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
