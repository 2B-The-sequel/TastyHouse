using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class SideViewModel
    {
        private readonly Side side;

        public string Name { get { return side.Name; } set { side.Name = value; } }

        public int Price { get { return side.Price; } set { side.Price = value; } }

        public SideViewModel (Side side)
        {
            this.side = side;
        }
    }
}
