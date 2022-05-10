using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class IngredientViewModel : ViewModel<Ingredient>
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

        public double ExtraPrice
        {
            get
            {
                return model.ExtraPrice;
            }
            set
            {
                model.ExtraPrice = value;
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
        public int Count_total
        {
            get
            {
                return model.Count;
            }
            set
            {
                model.Count = value;
            }
        }        



        public IngredientViewModel(Ingredient model) : base(model) { }
    }
}

