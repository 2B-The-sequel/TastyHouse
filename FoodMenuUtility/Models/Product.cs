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
        public string Type { get; set; }

        public Product(int id, string name, double price, string type, byte[] image)
        {
            Id = id;
            Name = name;
            Price = price;
            Type = type;
            Image = image;
        }

        public Product(int id, string name, double price, string type) :
            this(id, name, price, type, null)
        {

        }
        public Product(string name, double price, string type) :
            this(-1, name, price, type, null)
        {

        }
        public Product(string name, double price, string type, byte[] image) :
            this(-1, name, price, type, image)
        {

        }

    }
}
