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
        private int count;

        public int Count
        {
            get { return count; }
            set { count = value; }
        }


        public Ingredient(int id, string name, double extraPrice, byte[] image, int count)
        {
            Id = id;
            Name = name;
            ExtraPrice = extraPrice;
            Image = image;
            Count = count;
        }
        
        public Ingredient(string name, double extraPrice, byte[] image) :
            this(-1, name, extraPrice, image, 0)
        {

        }
        public Ingredient(int id, string name, double extraPrice, byte[] image) :
            this(id, name, extraPrice, image, 0)
        {

        }
        public Ingredient(string name, double extraPrice) :
            this(-1, name, extraPrice, null, 0)
        {

        }
        public Ingredient(int id, string name, double extraPrice) :
            this(id, name, extraPrice, null, 0)
        {

        }
    }

}

