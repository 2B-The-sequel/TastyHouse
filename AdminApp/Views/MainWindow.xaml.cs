using System;
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

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
            AddProductDialog addSideDialog = new();
            if (addSideDialog.ShowDialog() == true)
            {
                for (int i = 0; i < addSideDialog.IngredientBox.Items.Count; i++)
                {
                    if (addSideDialog.Ingredients[i].Count_total != 0)
                    {
                        MVM.IngredientsInProduct.Add(addSideDialog.Ingredients[i]);
                    }
                }
                MVM.AddProduct(addSideDialog.ProductName, double.Parse(addSideDialog.Price), (ProductType)addSideDialog.Type, addSideDialog.ProductImage);
            } 
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil slette dette?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MVM.RemoveProduct();
            }
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            AcceptDialog dialog = new();
            
            if (dialog.ShowDialog() == true)
            {
                string datestring = dialog.Hour + ":" + dialog.Minute;

                if (OnlyDigits(datestring))
                {
                    MVM.SelectedOrder.State = OrderState.Accepted;

                    MVM.SelectedOrder.DoneTime = DateTime.ParseExact(datestring, "t", null);
                    MVM.UpdateOrder(MVM.SelectedOrder.Id);
                }
                else
                {
                    MessageBox.Show("Input må kun være tal imellem \n 00 - 23 : 00 - 59" , "Input fejl", MessageBoxButton.OK, MessageBoxImage.Error);
                }
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
                MVM.AddIngredient(dialog.IngredientName, dialog.IngredientPrice, dialog.IngredientImage, dialog.IngredientSoldOut);
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
            dialog.IngredientSoldOut = MVM.SelectedIngredient.SoldOut;

            if (dialog.ShowDialog() == true)
            {
                MVM.EditIngredient(dialog.IngredientName, dialog.IngredientPrice, dialog.IngredientImage, dialog.IngredientSoldOut);
            }
        }

        //Metode til at tjekke input for Leveringstid færdigt i AdminApp
        public static bool OnlyDigits(string s)
        {
            bool onlyDigits = true;

            try
            {
                int holder = int.Parse(s[0].ToString() + s[1].ToString());
                int holder2 = int.Parse(s[3].ToString() + s[4].ToString());

                if (holder >= 24 || holder2 > 59)
                    onlyDigits = false;

                for (int i = 0; i < s.Length && onlyDigits; i++)
                {
                    if (!char.IsNumber(s[i]) && s[i] != ':')
                    {
                        onlyDigits = false;
                    }
                }
            }
            catch (Exception) { onlyDigits = false; }

            return onlyDigits;
        }
        
        private void EditProduct_Click(object sender, RoutedEventArgs e)
        {
        
        }
    }
}