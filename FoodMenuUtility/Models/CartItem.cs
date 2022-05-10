using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuUtility.Models
{
    public class CartItem
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public int Id { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        private ProductType productType;

        public ProductType ProductType
        {
            get { return productType; }
            set { productType = value; }
        }


        public CartItem (int id, string name, double price, ProductType productType )
        {
            Id = id;
            Name = name;
            Price = price;
            ProductType = productType;
        }

    }
}
