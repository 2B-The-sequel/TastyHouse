using System;
using System.Collections.Generic;
using System.Windows;
using AdminApp.ViewModels;
using AdminApp.Views;
using FoodMenuUtility.Models;

namespace AdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MVM;

        public MainWindow()
        {
            InitializeComponent();
            MVM = new MainViewModel();
            DataContext = MVM;
        }

        // Order
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            AcceptDialog dialog = new();

            if (dialog.ShowDialog() == true)
            {
                string datestring = dialog.Hour + ":" + dialog.Minute;

                MVM.SelectedOrder.State = OrderState.Accepted;
                MVM.SelectedOrder.DoneTime = DateTime.ParseExact(datestring, "t", null);
                MVM.UpdateOrder(MVM.SelectedOrder.Id);
            }
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil afvise orderen?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MVM.SelectedOrder.State = OrderState.Declined;
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            MVM.SelectedOrder.State = OrderState.Done;
        }

        // Product
        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                List<IngredientViewModel> ingredients = new();

                for (int i = 0; i < dialog.IngredientBox.Items.Count; i++)
                {
                    for (int j = 0; j < dialog.Ingredients[i].CountTotal; j++)
                    {
                        ingredients.Add(dialog.Ingredients[i]);
                    }
                }
                MVM.AddProduct(dialog.ProductName, dialog.Price, dialog.Type, dialog.ProductImage, ingredients);
            } 
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil slette dette?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MVM.RemoveProduct();
            }
        }

        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
            AddProductDialog dialog = new();
            dialog.ProductName = MVM.SelectedProduct.Name;
            dialog.Price = MVM.SelectedProduct.Price;
            dialog.ProductImage = MVM.SelectedProduct.Image;

            foreach (Ingredient ingredient in MVM.SelectedProduct.Ingredients)
            {
                foreach (IngredientViewModel ingredientViewModel in dialog.Ingredients)
                {
                    if (ingredient.Id == ingredientViewModel.Id)
                        ingredientViewModel.CountTotal++;
                }
            }

            if (dialog.ShowDialog() == true)
            {
                List<IngredientViewModel> ingredients = new();

                for (int i = 0; i < dialog.IngredientBox.Items.Count; i++)
                {
                    for (int j = 0; j < dialog.Ingredients[i].CountTotal; j++)
                    {
                        ingredients.Add(dialog.Ingredients[i]);
                    }
                }

                MVM.EditProduct(dialog.ProductName, dialog.Price, dialog.ProductImage, ingredients);
            }
        }

        // Ingredient
        private void NewIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddIngredientDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                MVM.AddIngredient(dialog.IngredientName, dialog.IngredientPrice, dialog.IngredientImage, dialog.IngredientSoldOut);
            }
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            DeleteIngredientDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                MVM.RemoveIngredient(dialog.DeleteProductsWithIngredient);
            }
        }        

        private void EditIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddIngredientDialog dialog = new();
            dialog.IngredientName = MVM.SelectedIngredient.Name;
            dialog.IngredientPrice = MVM.SelectedIngredient.ExtraPrice;
            dialog.IngredientImage = MVM.SelectedIngredient.Image;
            dialog.IngredientSoldOut = MVM.SelectedIngredient.SoldOut;

            if (dialog.ShowDialog() == true)
            {
                MVM.EditIngredient(dialog.IngredientName, dialog.IngredientPrice, dialog.IngredientImage, dialog.IngredientSoldOut);
            }
        }
    }
}