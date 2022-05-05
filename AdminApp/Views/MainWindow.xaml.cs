using System.Windows;
using AdminApp.ViewModels;
using AdminApp.Views;
using FoodMenuUtility.Models;


using FoodMenuUtility.Persistence;


namespace AdminApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContentRepo CR = new ContentRepo();
        ProductRepo pr = new ProductRepo();
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
                Product side = new Product(addSideDialog.name, int.Parse(addSideDialog.price), addSideDialog.type);
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
            NewMenu dialog = new();
            if (dialog.ShowDialog() == true)
            {

            }
        }
        private void AddNewContent(object sender, RoutedEventArgs e)
        {

            NewContent dialog = new();
            if (dialog.ShowDialog() == true)
            {
                Content content;
                if (dialog.image == null)
                {
                    content = new Content(dialog.name, dialog.price);

                }
                else
                {
                    content = new Content(dialog.name, dialog.price, dialog.image);
                }
                
                ContentViewModel CVM = new(content);
                CR.Add(content);
                MVM.Contents.Add(CVM);
            }
            
        }
        private void DeleteContent(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Er du sikker på at du vil slette dette?", "Bekræftelse", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
            {
                //Content value = (Content)Datagrid.SelectedValue;
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