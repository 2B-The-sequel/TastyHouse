using FoodMenuUtility.Models;

namespace PhoneApp.ViewModels
{
    public class CartViewModel : ViewModel<CartItem>
    {
        public int Id 
        { 
            get 
            { 
                return model.Id; 
            } 
            set 
            { 
                model.Id = value; 
            } 
        }

        public string Name 
        { 
            get 
            { 
                return model.Name; 
            } 
            set 
            { 
                model.Name = value; 
            } 
        }

        public double Price 
        { 
            get 
            { 
                return model.Price; 
            } 
            set 
            { 
                model.Price = value; 
            } 
        }

        public ProductType ProductType
        {
            get 
            { 
                return model.ProductType; 
            }
            set 
            { 
                model.ProductType = value; 
            }
        }

        public CartViewModel (CartItem model) : base(model) { }
    }
}