﻿using System.Windows;
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

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductDialog addSideDialog = new();
            if (addSideDialog.ShowDialog() == true)
            {
                for (int i = 0; i < MVM.IngredientsInProduct.Count; i++)
                {
                    MVM.Ingredients.Count.ToString();
                }
                Product side = new(addSideDialog.ProductName, int.Parse(addSideDialog.Price), (ProductType)addSideDialog.Type);
                ProductViewModel _side = new(side);
                MVM.Sides.Add(_side);
            } 
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            AcceptDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                MVM.SelectedOrder.State = OrderState.Accepted;
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

        

        private void NewIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddContentDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                MVM.AddIngredient(dialog.IngredientName, dialog.IngredientPrice, dialog.IngredientImage);
            }
        }

        private void DeleteIngredient_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil slette dette?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MVM.RemoveIngredient();
            }
        }        

        private void EditIngredient_Click(object sender, RoutedEventArgs e)
        {
            AddContentDialog dialog = new();
            dialog.IngredientName = MVM.SelectedIngredient.Name;
            dialog.IngredientPrice = MVM.SelectedIngredient.ExtraPrice;
            dialog.IngredientImage = MVM.SelectedIngredient.Image;

            if (dialog.ShowDialog() == true)
            {
                MVM.EditIngredient(dialog.IngredientName, dialog.IngredientPrice, dialog.IngredientImage);
            }
        }
    }
}