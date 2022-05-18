using System;

namespace FoodMenuUtility.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        private byte[] image = Array.Empty<byte>();
        public byte[] Image
        {
            get 
            { 
                return image;
            }
            set
            { 
                image = value;
            }
        }

        public string Name { get; set; }

        public double ExtraPrice { get; set; }

        public bool SoldOut { get; set; }

        public Ingredient(int id, string name, double extraPrice, byte[] image, bool soldOut)
        {
            Id = id;
            Name = name;
            ExtraPrice = extraPrice;
            Image = image;
            SoldOut = soldOut;
        }
    }
}