using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for NewMenu.xaml
    /// </summary>
    public partial class AddMenuDialog : Window
    {
        public string MenuName { get; set; }
        public double Price { get; set; }
        public byte[] Image { get; set; }

        public AddMenuDialog()
        {
            InitializeComponent();
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
