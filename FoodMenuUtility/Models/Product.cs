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

        public int Price { get; set; }  

        //byte[] Image { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }

        public Product(string name, int price, int id, string type)
        {
            Name = name;
            Price = price;
            Id = id;
            Type = type;
        }

        public Product(string name, int price, )
    }
}
