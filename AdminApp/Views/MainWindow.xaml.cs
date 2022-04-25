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

        private void AddSideButton_Click(object sender, RoutedEventArgs e)
        {
           AddSideDialog addSideDialog = new AddSideDialog();
           if (addSideDialog.ShowDialog() == true)
            {
                Side side = new Side(addSideDialog.name, int.Parse(addSideDialog.price));
                SideViewModel _side = new(side);
                MVM.Sides.Add(_side);
            } 
        }

        private void RemoveSideButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}