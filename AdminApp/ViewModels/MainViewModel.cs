using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public ObservableCollection<ProductViewModel> Sides { get; set; }
        public ObservableCollection<IngredientViewModel> Ingredients { get; set; }

        private readonly IngredientRepo IR = new();

        public OrderViewModel SelectedOrder { get; set; }
        public IngredientViewModel SelectedContent { get; set; }

        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Ingredients = new ObservableCollection<IngredientViewModel>();

            Sides = new ObservableCollection<ProductViewModel> { };

            //TESTING
            for (int i = 1; i <= 10; i++)
            {
                Order order = new(i);
                OrderViewModel ovm = new(order);
                Orders.Add(ovm);
            }

            List<Ingredient> contentList = IR.GetAll();
            foreach (Ingredient content in contentList)
            {
                Ingredients.Add(new IngredientViewModel (content));
            }
        }

        public void AddContent(string name, double price, byte[] image)
        {
            Ingredient ingredients = IR.Create(name, price, image);
            IngredientViewModel CVM = new(ingredients);
            Ingredients.Add(CVM);
        }

        public void RemoveContent()
        {
            IR.Remove(SelectedContent.Id);
            Ingredients.Remove(SelectedContent);
        }
    }
}