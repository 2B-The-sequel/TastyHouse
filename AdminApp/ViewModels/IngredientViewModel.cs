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

        public double ExtraPrice
        {
            get
            {
                return model.ExtraPrice;
            }
            set
            {
                model.ExtraPrice = value;
                NotifyPropertyChanged(nameof(ExtraPrice));
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

        private int countTotal;

        public int CountTotal
        {
            get 
            { 
                return countTotal; 
            }
            set 
            { 
                countTotal = value;
                NotifyPropertyChanged(nameof(CountTotal));
            }
        }

        public bool SoldOut
        {
            get
            {
                return model.SoldOut;
            }
            set
            {
                model.SoldOut = value;
                NotifyPropertyChanged(nameof(SoldOut));
            }
        }

        public IngredientViewModel(Ingredient model) : base(model) { }
    }
}