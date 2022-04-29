using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuUtility.Models
{
    public class Content
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
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

        public Content(int id, string name, double extraPrice)
        {
            Id = id;
            Name = name;
            ExtraPrice = extraPrice;
        }
        public Content(string name, double extraPrice):
            this (-1, name, extraPrice)
        {

        }
    }
}
