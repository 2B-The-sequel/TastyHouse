using AdminApp.ViewModels;
using Microsoft.Win32;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Windows;
using FoodMenuUtility.Models;
using FoodMenuUtility.Persistence;
using System.ComponentModel;
using System.Windows.Input;
using System.Text.RegularExpressions;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for AddSideWindow.xaml
    /// </summary>
    public partial class AddProductDialog : Window, INotifyPropertyChanged
    {
        public ObservableCollection<IngredientViewModel> Ingredients { get; set; }

        private string _productName = string.Empty;
        public string ProductName
        {
            get 
            { 
                return _productName; 
            }
            set
            {
                _productName = value;
                NotifyPropertyChanged(nameof(_productName));
            }
        }

        private double _price = 0.0;
        public double Price
        {
            get 
            { 
                return _price; 
            }
            set 
            { 
                _price = value; 
                NotifyPropertyChanged(nameof(_price)); 
            }
        }

        private int _type;
        public ProductType Type
        {
            get 
            { 
                return (ProductType)_type; 
            }
            set 
            { 
                _type = (int)value; 
                NotifyPropertyChanged(nameof(_type)); 
            }
        }

        private byte[] _productImage;
        public byte[] ProductImage
        {
            get 
            { 
                return _productImage; 
            }
            set 
            { 
                _productImage = value; 
                NotifyPropertyChanged(nameof(ProductImage)); 
            }
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

        public AddProductDialog()
        {
            InitializeComponent();
            DataContext = this;
            Ingredients = new ObservableCollection<IngredientViewModel>();
            List<Ingredient> test = IngredientRepo.Instance.RetrieveAll();

            foreach (Ingredient content in test)
            {
                Ingredients.Add(new IngredientViewModel(content));
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
            if (ProductName == null || ProductName.Trim() == string.Empty)
                MessageBox.Show("Madvaren skal have et navn.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (ProductImage == null)
                MessageBox.Show("Du har ikke valgt et billede til madvaren.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult= false;
        }

        /// <summary>
        /// Ensures that the textbox can only contain numbers.
        /// </summary>
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
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