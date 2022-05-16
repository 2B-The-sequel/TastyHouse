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

        public OrderViewModel SelectedOrder { get; set; }
        public ProductViewModel SelectedProduct { get; set; }
        public IngredientViewModel SelectedIngredient { get; set; }

        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Ingredients = new ObservableCollection<IngredientViewModel>();
            Products = new ObservableCollection<ProductViewModel> {};

            //TESTING
            for (int i = 1; i <= 10; i++)
            {
                Order order = new(i);
                OrderViewModel ovm = new(order);
                Orders.Add(ovm);
            }
            //TEST SLUT :(

            List<Ingredient> contentList = IngredientRepo.Instance.GetAll();
            foreach (Ingredient content in contentList)
            {
                Ingredients.Add(new IngredientViewModel(content));
            }

            List<Product> ProList = ProductRepo.Instance.GetAll();
            foreach (Product prolist in ProList)
            {
                Products.Add(new ProductViewModel(prolist));
            }            
        }

        // Products
        public void AddProduct(string name, double price,ProductType type, byte[] image, List<IngredientViewModel> ingredients)
        {
            List<int> ingredient_ids = new();
            for (int i = 0; i < ingredients.Count; i++)
            {
                ingredient_ids.Add(ingredients[i].Id);
            }

            Product product = ProductRepo.Instance.Create(name, price, type, image, ingredient_ids);
            ProductViewModel pvm = new(product);
            Products.Add(pvm);
        }
      
        public void RemoveProduct()
        {
            ProductRepo.Instance.Delete(SelectedProduct.Id);
            Products.Remove(SelectedProduct);
        }

        public void AddIngredientToProduct(IngredientViewModel ingredient)
        {
            SelectedProduct.Ingredients.Add(IngredientRepo.Instance.GetById(ingredient.Id));
        }

        // Ingredients
        public void AddIngredient(string name, double price, byte[] image, bool soldOut)
        {
            Ingredient ingredients = IngredientRepo.Instance.Create(name, price, image, soldOut);
            IngredientViewModel ivm = new(ingredients);
            Ingredients.Add(ivm);
        }

        public void EditIngredient(string name, double price, byte[] image, bool soldOut)
        {
            SelectedIngredient.Name = name;
            SelectedIngredient.ExtraPrice = price;
            SelectedIngredient.Image = image;
            SelectedIngredient.SoldOut = soldOut;

            IngredientRepo.Instance.Update(SelectedIngredient.Id);
        }

        public void RemoveIngredient()
        {
            IngredientRepo.Instance.Delete(SelectedIngredient.Id);
            Ingredients.Remove(SelectedIngredient);
        }
    }
}