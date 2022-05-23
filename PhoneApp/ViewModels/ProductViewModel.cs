using FoodMenuUtility.Models;

namespace PhoneApp.ViewModels
{
    public class ProductViewModel : ViewModel<Product>
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

        public byte[] Image
        {
            get
            {
                return model.Image;
            }
            set
            {
                model.Image = value;
            }
        }

        public string IngredientsText
        {
            get
            {
                string ingredients = string.Empty;

                for (int i = 0; i < model.Ingredients.Count; i++)
                {
                    ingredients += model.Ingredients[i].Name + ((i == model.Ingredients.Count - 1) ? string.Empty : ", ");
                }

                return ingredients;
            }
        }

        public ProductViewModel(Product model) : base(model) { }
    }
}