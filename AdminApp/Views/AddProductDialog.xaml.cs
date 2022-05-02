using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for AddSideWindow.xaml
    /// </summary>
    public partial class AddProductDialog : Window
    {
        public AddProductDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        public string ProductName { get; set; } 
        public string Price { get; set; } 
        public string Type { get; set; }
        public byte[] Image { get; set; }

        private void OpenImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
               FileStream fileStream = new(openFileDialog.FileName, FileMode.Open, FileAccess.Read);
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
            DialogResult= false;
        }
    }
}