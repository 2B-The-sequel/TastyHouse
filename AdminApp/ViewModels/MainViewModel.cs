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
            IngredientsInProduct = new ObservableCollection<IngredientViewModel>();
            PR = new();
            Products = new ObservableCollection<ProductViewModel> {};

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
            List<Product> ProList = PR.GetAll();
            foreach (Product prolist in ProList)
            {

                Products.Add(new ProductViewModel(prolist));

            }            
        }

        public void AddProduct(string name, double price,ProductType type, byte[] image)
        {

            Product side = PR.Add(name, price, type, image);
            ProductViewModel _side = new(side);
            Products.Add(_side);

            
            int pro_id = side.Id;
            for (int i = 0; i < IngredientsInProduct.Count; i++)
            {
                for (int x = 0; x < IngredientsInProduct[i].Count_total; x++)
                {
                    int id = IngredientsInProduct[i].Id;
                    PR.AddToProdukt(id, pro_id);
                }
                
            }
            IngredientsInProduct.Clear();
            
        }

            
        public void AddIngredient(string name, double price, byte[] image, bool soldOut)
        {
            Ingredient ingredients = IR.Create(name, price, image, soldOut);
            IngredientViewModel ivm = new(ingredients);
            Ingredients.Add(ivm);
        }


        public void EditIngredient(string name, double price, byte[] image, bool soldOut)
        {
            SelectedIngredient.Name = name;
            SelectedIngredient.ExtraPrice = price;
            SelectedIngredient.Image = image;
            SelectedIngredient.SoldOut = soldOut;

            //MANGLER AT SENDE VIDERE TIL SQL
        }
        public void GetIngredientsInBurger()
        {

        }

        public void RemoveIngredient()
        {
            IR.Remove(SelectedIngredient.Id);
            Ingredients.Remove(SelectedIngredient);
        }
        public void RemoveProduct()
        {
            PR.Remove(SelectedProduct.Id);
            Products.Remove(SelectedProduct);
        }
    }
}