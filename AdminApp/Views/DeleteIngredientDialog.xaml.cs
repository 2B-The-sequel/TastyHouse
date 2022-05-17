using System.Windows;

namespace AdminApp.Views
{
    /// <summary>
    /// Interaction logic for DeleteIngredientDialog.xaml
    /// </summary>
    public partial class DeleteIngredientDialog : Window
    {
        public bool RemoveIngredientFromProduct { get; set; }

        public DeleteIngredientDialog()
        {
            InitializeComponent();
            DataContext = this;
        }

        private void RemoveIngredientFromProduct_Click(object sender, RoutedEventArgs e)
        {
            RemoveIngredientFromProduct = true;
            DialogResult = true;
        }

        private void RemoveProductsWithIngredient_Click(object sender, RoutedEventArgs e)
        {
            RemoveIngredientFromProduct = false;
            DialogResult = true;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}
