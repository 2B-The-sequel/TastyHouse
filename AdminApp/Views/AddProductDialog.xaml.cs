using AdminApp.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;
using System.ComponentModel;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for AddSideWindow.xaml
    /// </summary>
    public partial class AddProductDialog : Window, INotifyPropertyChanged
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

        private string productName = string.Empty;

        public string ProductName
        {
            get { return productName; }
            set
            {
                productName = value;
                NotifyPropertyChanged(nameof(productName));
            }
        }
        private string price = string.Empty;

        public string Price
        {
            get { return price; }
            set { price = value; NotifyPropertyChanged(nameof(price)); }
        }
        private int type;

        public int Type
        {
            get { return type; }
            set { type = value; NotifyPropertyChanged(nameof(type)); }
        }
        private byte[] productImage;

        public byte[] ProductImage
        {
            get { return productImage; }
            set { productImage = value; NotifyPropertyChanged(nameof(productImage)); }
        }


        private string _imagePath = string.Empty;


        public string ImagePath
        {
            get
            {
                return _imagePath;
            }
            set
            {
                _imagePath = value;
                NotifyPropertyChanged(nameof(ImagePath));
            }
        }



        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                ProductImage = File.ReadAllBytes(openFileDialog.FileName);
                ImagePath = openFileDialog.FileName;
            }
        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            
            
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Used to notify UI of changes in a property.
        /// </summary>
        // <param name="propertyName">Name of the property changed.</param>
        protected void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}