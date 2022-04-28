using System;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp.ViewModels
{
    public class ContentViewModel : ViewModel<Content>
    {
        MainViewModel MVM = new();
        ContentRepo CR = new ContentRepo();
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
        


       
        public void AddContent(string name, double extraPrice)
        {
            Content content = new Content(name, extraPrice);
            int addContent = CR.Add(content);
            CR.GetAll();
        }
        public Content GetContent(int id)
        {
            Content content = null;
            foreach (Content con in MVM.Contents)
            {

            }
        }

        public ContentViewModel(Content model) : base(model) {
            

        }
    }
}
