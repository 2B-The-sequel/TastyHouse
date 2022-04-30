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

        byte[] Image { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }

        public Product(string name, double price, int id, string type, byte[] image)
        {
            Name = name;
            Price = price;
            Id = id;
            Type = type;
            Image = image;
        }

        public Product(string name, double price, int id, string type) :
            this(name, price, id, type, null)
        {

        }
        public Product(string name, double price, string type) :
            this(name, price, -1, type, null)
        {

        }
        public Product(string name, double price, string type, byte[] image) :
            this(name, price, -1, type, image)
        {

        }

    }
}
