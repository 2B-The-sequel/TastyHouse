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

            List<Order> orderList = OrderRepo.Instance.RetrieveAll();
            foreach (Order order in orderList)
            {
                Orders.Add(new OrderViewModel(order));
            }

            List<Ingredient> ingredientList = IngredientRepo.Instance.RetrieveAll();
            foreach (Ingredient ingredient in ingredientList)
            {
                Ingredients.Add(new IngredientViewModel(ingredient));
            }

            List<Product> productList = ProductRepo.Instance.RetrieveAll();
            foreach (Product product in productList)
            {
                Products.Add(new ProductViewModel(product));
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


        public void EditProduct(string name, double price, byte[] image, List<IngredientViewModel> ingredientViewModels)
        {
            List<Ingredient> ingredients = new();
            for (int i = 0; i < ingredientViewModels.Count; i++)
            {
                ingredients.Add(IngredientRepo.Instance.Retrieve(ingredientViewModels[i].Id));
            }

            SelectedProduct.Name = name;
            SelectedProduct.Price = price;
            SelectedProduct.Image = image;
            SelectedProduct.Ingredients = ingredients;

            ProductRepo.Instance.Update(SelectedProduct.Id);
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

        public void RemoveIngredient(bool DeleteProductsWithIngredient)
        {
            if (DeleteProductsWithIngredient)
            {
                List<int> productsToBeDeleted = new List<int>();

                foreach (Product product in ProductRepo.Instance.RetrieveAll())
                {
                    bool found = false;
                    int i = 0;
                    while (i < product.Ingredients.Count && !found)
                    {
                        if (product.Ingredients[i].Id == SelectedIngredient.Id)
                            found = true;
                        else
                            i++;
                    }

                    if (found)
                        productsToBeDeleted.Add(product.Id);
                }

                for (int i = 0; i < productsToBeDeleted.Count; i++)
                {
                    ProductRepo.Instance.Delete(productsToBeDeleted[i]);
                }
            }

            IngredientRepo.Instance.Delete(SelectedIngredient.Id);
            Ingredients.Remove(SelectedIngredient);

            // Update current products so they dont have ingredient
        }

        // EDIT ORDER
        public void UpdateOrder(int id)
        {
            OrderRepo.Instance.Update(id);
        }
    }
}