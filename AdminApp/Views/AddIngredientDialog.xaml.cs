using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for NewContent.xaml
    /// </summary>
    public partial class AddContentDialog : Window, INotifyPropertyChanged
    {
        private string _ingredientName = string.Empty;
        public string IngredientName 
        { 
            get
            {
                return _ingredientName;
            }
            set
            {
                _ingredientName = value;
                NotifyPropertyChanged(nameof(IngredientName));
            }
        }

        private double _ingredientPrice = 0.0;
        public double IngredientPrice
        { 
            get
            {
                return _ingredientPrice;
            }
            set
            {
                _ingredientPrice = value;
                NotifyPropertyChanged(nameof(IngredientPrice));
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

        private byte[] _ingredientImage = null;
        public byte[] IngredientImage
        {
            get
            {
                return _ingredientImage;
            }
            set
            {
                _ingredientImage = value;
                NotifyPropertyChanged(nameof(IngredientImage));
            }
        }

        private bool _ingredientSoldOut = false;
        public bool IngredientSoldOut
        { 
            get
            {
                return _ingredientSoldOut;
            }
            set
            {
                _ingredientSoldOut = value;
                NotifyPropertyChanged(nameof(IngredientSoldOut));
            } 
        }

        public AddContentDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
            if (IngredientName == null || IngredientName.Trim() == string.Empty)
                MessageBox.Show("Ingrediensen skal have et navn.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            else if (IngredientImage == null)
                MessageBox.Show("Du har ikke valgt et billede til ingrediensen.", "Fejl", MessageBoxButton.OK, MessageBoxImage.Error);
            else
                DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }

        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files (*.png;*.jpeg;*.jpg)|*.png;*.jpeg;*.jpg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                IngredientImage = File.ReadAllBytes(openFileDialog.FileName);
                ImagePath = openFileDialog.FileName;
            }
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