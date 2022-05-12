
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


        public Product(int id, string name, double price, ProductType type, byte[] image, List<Ingredient> ingredients)
        {
            Id = id;
            Name = name;
            Price = price;
            ProductType = type;
            Image = image;
            Ingredients = ingredients;
        }

        public Product(int id, string name, double price, ProductType type, byte[] image) :
            this(id, name, price, type, image, new List<Ingredient>())
        {

        }
        public Product(string name, double price, ProductType type, byte[] image) :
            this(-1, name, price, type, image, new List<Ingredient>())
        {

        }
        public Product(string name, double price, ProductType type, byte[] image, List<Ingredient> ingredients) :
            this(-1, name, price, type, image, ingredients)
        {

        }
        public Product(string name, double price, ProductType type) :
            this(-1, name, price, type, null, new List<Ingredient>())
        {

        }
        public Product(int id, string name, double price, ProductType type, List<Ingredient> ingredients) :
            this(id, name, price, type, null, ingredients)
        {

        }
        public Product(string name, double price, ProductType type, List<Ingredient> ingredients) :
            this(-1, name, price, type, null, ingredients)
        {

        }


    }
}
