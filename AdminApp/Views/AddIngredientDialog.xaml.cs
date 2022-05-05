using Microsoft.Win32;
using System.IO;
using System.Windows;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for NewContent.xaml
    /// </summary>
    public partial class AddContentDialog : Window
    {
        public string IngredientsName { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }

        public AddContentDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void SaveIngredientButton_Click(object sender, RoutedEventArgs e)
        {
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
                Image = File.ReadAllBytes(openFileDialog.FileName);
            }
        }
    }
}