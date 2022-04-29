using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class ProductViewModel
    {
        private readonly Product product;

        public string Name { get { return product.Name; } set { product.Name = value; } }

        public int Price { get { return product.Price; } set { product.Price = value; } }

        public ProductViewModel (Product side)
        {
            this.product = side;
        }
    }
}
