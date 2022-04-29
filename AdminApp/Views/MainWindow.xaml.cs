using System.Windows;
using AdminApp.ViewModels;
using AdminApp.Views;
using FoodMenuUtility.Models;

namespace AdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainViewModel MVM;

        public MainWindow()
        {
            InitializeComponent();
            MVM = new MainViewModel();
            DataContext = MVM;
        }

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
        {
           AddProductDialog addSideDialog = new AddProductDialog();
           if (addSideDialog.ShowDialog() == true)
            {
                Product side = new Product(addSideDialog.name, int.Parse(addSideDialog.price), addSideDialog.image);
                ProductViewModel _side = new(side);
                MVM.Sides.Add(_side);
            } 
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}