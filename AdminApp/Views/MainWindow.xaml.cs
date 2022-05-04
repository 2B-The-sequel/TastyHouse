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
            AddProductDialog addSideDialog = new();
            if (addSideDialog.ShowDialog() == true)
            {
                Product side = new(addSideDialog.ProductName, int.Parse(addSideDialog.Price), addSideDialog.Type);
                ProductViewModel _side = new(side);
                MVM.Sides.Add(_side);
            } 
        }

        private void RemoveProductButton_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            AcceptDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                MVM.SelectedOrder.State = OrderState.Accepted;
            }
        }

        private void Decline_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil afvise orderen?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MVM.SelectedOrder.State = OrderState.Declined;
            }
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            MVM.SelectedOrder.State = OrderState.Done;
        }

        private void New_Menu(object sender, RoutedEventArgs e)
        {
            AddMenuDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {

            }
        }

        private void AddNewContent(object sender, RoutedEventArgs e)
        {
            AddContentDialog dialog = new();
            if (dialog.ShowDialog() == true)
            {
                MVM.AddContent(dialog.ContentName, dialog.Price, dialog.Image);
            }
        }

        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil slette dette?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                MVM.RemoveContent();
            }
        }        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil afvise orderen?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                
            }
        }
    }
}