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


        public Menu(string name, int id, byte[] image)
        {
            Name = name;
            Id = id;
            Image = image;
        }
    }
}
