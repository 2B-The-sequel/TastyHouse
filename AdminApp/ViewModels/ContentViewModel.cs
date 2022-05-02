using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class ContentViewModel : ViewModel<Content>
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

        public ContentViewModel(Content model) : base(model) { }
    }
}
