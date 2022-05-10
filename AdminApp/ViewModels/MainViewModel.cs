using System.Collections.Generic;
using System.Collections.ObjectModel;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp.ViewModels
{
    public class MainViewModel
    {
        public ObservableCollection<OrderViewModel> Orders { get; set; }

        public ObservableCollection<ProductViewModel> Products { get; set; }
        public ObservableCollection<IngredientViewModel> Ingredients { get; set; }
        public ObservableCollection<IngredientViewModel> IngredientsInProduct { get; set; }

        private readonly IngredientRepo IR = IngredientRepo.Instance;
        public ProductRepo PR;

        public OrderViewModel SelectedOrder { get; set; }
        public ProductViewModel SelectedProduct { get; set; }
        public IngredientViewModel SelectedIngredient { get; set; }

        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Ingredients = new ObservableCollection<IngredientViewModel>();

            Products = new ObservableCollection<ProductViewModel> { };

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

                Ingredients.Add(new IngredientViewModel(content));

            }
        }

        public void AddProduct(string name, double price,ProductType type, byte[] image)
        {
            Product side = PR.Add(name, price, type, image);
            ProductViewModel _side = new(side);
            Products.Add(_side);

            
            int pro_id = _side.id;
            for (int i = 0; i < IngredientsInProduct.Count; i++)
            {
                int id = IngredientsInProduct[i].Id;
                PR.AddToProdukt(id, pro_id);
            }
            
        }
        public void AddContentToProduct(IngredientViewModel IVM)
        {
            

        }
        public void AddContent(string name, double price, byte[] image)
        {
            Ingredient ingredients = IR.Create(name, price, image);
            IngredientViewModel CVM = new(ingredients);
            Ingredients.Add(CVM);
        }
        

        public void RemoveContent()
        {
            IR.Remove(SelectedIngredient.Id);
            Ingredients.Remove(SelectedIngredient);
        }
    }
}