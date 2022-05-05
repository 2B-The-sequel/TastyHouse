using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace FoodMenuUtility.Models
{
    public class Product
    {
        public string Name { get; set; }

        public double Price { get; set; }  

        public byte[] Image { get; set; }
        public int Id { get; set; }
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
        }

        public Product(int id, string name, double price, ProductType type) :
            this(id, name, price, type, null)
        {

        }
        public Product(string name, double price, ProductType type) :
            this(-1, name, price, type, null)
        {

        }
        public Product(string name, double price, ProductType type, byte[] image) :
            this(-1, name, price, type, image)
        {

        }

    }
}
