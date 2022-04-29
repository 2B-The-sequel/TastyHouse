using System;
using FoodMenuUtility.Models;

namespace AdminApp.ViewModels
{
    public class MenuViewModel : ViewModel<Menu>
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

        public byte[] Image
        {
            get { return model.Image; }
            set { model.Image = value; }
        }


        public MenuViewModel(Menu model) : base(model) { }
    }
}
