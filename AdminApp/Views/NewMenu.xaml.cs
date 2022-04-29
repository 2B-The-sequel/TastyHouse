using System.Windows;
using AdminApp.ViewModels;
using AdminApp.Views;
using FoodMenuUtility.Models;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for NewMenu.xaml
    /// </summary>
    public partial class NewMenu : Window
    {
        public NewMenu NM = new();
        public NewMenu()
        {
            InitializeComponent();
        }
        private void SaveTenantButton_Click(object sender, RoutedEventArgs e)
        {
            NM = new();
            //Data sendes vidre her fra 
            NM.Name = MenuName.Text;

            DialogResult = true;
        }

        private void CancelButton1_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
