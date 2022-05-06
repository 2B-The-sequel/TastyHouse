using AdminApp.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for AddSideWindow.xaml
    /// </summary>
    public partial class AddProductDialog : Window
    {
        public ObservableCollection<IngredientViewModel> Ingredients { get; set; }
        public AddProductDialog()
        {
            InitializeComponent();
            DataContext = this;
            Ingredients = new ObservableCollection<IngredientViewModel>();
            List<Ingredient> test = IngredientRepo.Instance.GetAll();

            foreach (Ingredient content in test)
            {
                Ingredients.Add(new IngredientViewModel(content));
            }
        }

        public string ProductName { get; set; } 
        public string Price { get; set; } 
        public int Type { get; set; }
        public byte[] Image { get; set; }

        

        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                Image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            /*for (int i = 0; i < IngredientBox.Items.Count; i++)
            {
                IngredientViewModel humpe = Ingredients[i];
                IngredientViewModel ivm = (IngredientViewModel)IngredientBox.Items[i];
                string id = IngredientBox.Items[i].ToString();
                

            }*/
            
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
    }
}