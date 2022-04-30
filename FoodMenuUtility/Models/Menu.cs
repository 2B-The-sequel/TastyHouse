using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuUtility.Models
{
    public class Menu
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double price;

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private byte[] image;

        public byte[] Image
        {
            get { return image; }
            set { image = value; }
        }


        public Menu(int id, string name, byte[] image, double price) // with everything!
        {
            Name = name;
            Id = id;
            Image = image;
            Price = price;
        }
        public Menu(string name, byte[] image, double price) :// with image no id
                this(-1, name, image, price)
        {

        }
        public Menu(string name, double price) : // without id or image
                this(-1, name, null, price)
        {

        }
        public Menu(int id, string name, double price) : // without image but id
                this(id, name, null, price)
        {

        }


    }
}
