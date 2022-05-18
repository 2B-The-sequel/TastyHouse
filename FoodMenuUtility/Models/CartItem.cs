using System.Collections.Generic;

namespace FoodMenuUtility.Models
{
    public class CartItem
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Id { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public ProductType ProductType { get; set; }

        public CartItem (int id, string name, double price, ProductType productType)
        {
            Id = id;
            Name = name;
            Price = price;
            ProductType = productType;
        }
    }
}
