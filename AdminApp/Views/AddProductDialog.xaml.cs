using AdminApp.ViewModels;
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
        public MainViewModel MVM;
        public AddProductDialog()
        {
            InitializeComponent();
            MVM = new MainViewModel();
            DataContext = MVM;
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
                Image = File.ReadAllBytes(openFileDialog.FileName);
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