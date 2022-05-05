using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuUtility.Models
{
    public class Ingredient
    {
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
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private double extraPrice;

        public double ExtraPrice
        {
            get { return extraPrice; }
            set { extraPrice = value; }
        }

        public Ingredient(int id, string name, double extraPrice, byte[] image)
        {
            Id = id;
            Name = name;
            ExtraPrice = extraPrice;
            Image = image;
        }
        public Ingredient(string name, double extraPrice, byte[] image) :
            this(-1, name, extraPrice, image)
        {

        }
        public Ingredient(string name, double extraPrice) :
            this(-1, name, extraPrice, null)
        {

        }
        public Ingredient(int id, string name, double extraPrice) :
            this(id, name, extraPrice, null)
        {

        }
    }
}