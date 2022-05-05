using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace PhoneApp.ViewModels
{
    public class MenuViewModel : ViewModel<Menu>
    {
        public int id
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
        public string name
        {
            get { return model.Name; }
            set { model.Name = value; }
        }
        public double price
        {
            get { return model.Price; }
            set { model.Price = value; }
        }
        

        public byte[] image
        {
            get { return model.Image; }
            set { model.Image = value; }
        }
        

        public MenuViewModel(Menu model) : base(model) { }
    }
}
