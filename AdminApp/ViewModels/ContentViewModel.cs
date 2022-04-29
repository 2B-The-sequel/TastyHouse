using System;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp.ViewModels
{
    public class ContentViewModel : ViewModel<Content>
    {
        //MainViewModel MVM = new();
        //ContentRepo CR = new ContentRepo();
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
        public double ExstraPrice
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

        //public byte[] Image

        public ContentViewModel(Content model) : base(model) {
            

        }
    }
}
