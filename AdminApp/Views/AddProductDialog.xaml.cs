using AdminApp.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        public string name { get; set; } 
        public string price { get; set; } 
        public string type { get; set; }
        public byte[] image { get; set; }
        

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
            DialogResult= false;
        }
    }
}
