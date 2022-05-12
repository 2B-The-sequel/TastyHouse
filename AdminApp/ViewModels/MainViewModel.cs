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

        public OrderViewModel SelectedOrder { get; set; }
        public ProductViewModel SelectedProduct { get; set; }
        public IngredientViewModel SelectedIngredient { get; set; }

        public MainViewModel()
        {
            Orders = new ObservableCollection<OrderViewModel>();
            Ingredients = new ObservableCollection<IngredientViewModel>();
            IngredientsInProduct = new ObservableCollection<IngredientViewModel>();
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
        public void AddProduct(string name, double price,ProductType type, byte[] image)
        {
            Product product = ProductRepo.Instance.Create(name, price, type, image);
            ProductViewModel pvm = new(product);
            Products.Add(pvm);
            
            int pro_id = product.Id;
            for (int i = 0; i < IngredientsInProduct.Count; i++)
            {
                for (int x = 0; x < IngredientsInProduct[i].Count_total; x++)
                {
                    int id = IngredientsInProduct[i].Id;
                    ProductRepo.Instance.AddToProduct(id, pro_id);
                }
            }
            IngredientsInProduct.Clear();
        }
      
        public void RemoveProduct()
        {
            ProductRepo.Instance.Delete(SelectedProduct.Id);
            Products.Remove(SelectedProduct);
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