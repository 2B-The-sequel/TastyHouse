using System.Collections.Generic;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
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
                NotifyPropertyChanged(nameof(Id));
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
                NotifyPropertyChanged(nameof(Name));
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
                NotifyPropertyChanged(nameof(Price));

            }
        }

        public List<Ingredient> Ingredients 
        { 
            get 
            { 
                return model.Ingredients; 
            } 
            set 
            { 
                model.Ingredients  = value;
                NotifyPropertyChanged(nameof(Ingredients));
            } 
        }

        public int ProductType
        {
            get 
            {
                return (int)model.ProductType; 
            }
            set 
            { 
                model.ProductType = (ProductType)value; 
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
                NotifyPropertyChanged(nameof(Image));
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

        public ProductViewModel (Product model) : base (model) { }
    }
}