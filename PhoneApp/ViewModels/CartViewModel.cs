using FoodMenuUtility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneApp.ViewModels
{
    public class CartViewModel : ViewModel<CartItem>
    {
        private readonly CartItem cartItem;
        public int Id { get { return cartItem.Id; } set { cartItem.Id = value; } }
        public string Name { get { return cartItem.Name; } set { cartItem.Name = value; } }

        public double Price { get { return cartItem.Price; } set { cartItem.Price = value; } }

        private ProductType productType;

        public ProductType ProductType
        {
            get { return (ProductType)cartItem.ProductType; }
            set { cartItem.ProductType = (ProductType)value; }
        }

        public CartViewModel (CartItem model) : base(model)
        {
            this.cartItem = model;
        }


    }
}
