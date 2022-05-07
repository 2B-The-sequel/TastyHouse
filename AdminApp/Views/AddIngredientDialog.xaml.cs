using Microsoft.Win32;
using System.ComponentModel;
using System.IO;
using System.Windows;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for NewContent.xaml
    /// </summary>
    public partial class AddContentDialog : Window, INotifyPropertyChanged
    {
        public string IngredientName { get; set; }
        public double IngredientPrice { get; set; }

        private string _imagePath = string.Empty;
        private string ImagePath 
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
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                IngredientImage = File.ReadAllBytes(openFileDialog.FileName);
                ImagePath = openFileDialog.FileName;
            }
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