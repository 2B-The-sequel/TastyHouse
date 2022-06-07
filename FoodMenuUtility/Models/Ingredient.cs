using System;

namespace FoodMenuUtility.Models
{
    public class Ingredient
    {
        // Også en property
        public int Id { get; set; }

        // Private backing field
        private byte[] image = Array.Empty<byte>(); // Sat til tomt array i stedet for null, da null giver fejl
        
        // Property
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