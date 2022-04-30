using System.IO;
using System.Windows;
using AdminApp.ViewModels;
using AdminApp.Views;
using FoodMenuUtility.Models;
using Microsoft.Win32;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for NewMenu.xaml
    /// </summary>
    public partial class NewMenu : Window
    {
        MainViewModel MVM;
        public string name { get; set; }
        public double price { get; set; }
        public byte[] image { get; set; }
        public NewMenu()
        {
            InitializeComponent();
        }

        
        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                FileStream fileStream = new FileStream(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
                byte[] image = new byte[fileStream.Length];
                fileStream.Read(image, 0, image.Length);

            }

        }

        private void SaveProductButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
