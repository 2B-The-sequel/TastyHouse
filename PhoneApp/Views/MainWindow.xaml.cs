using PhoneApp.ViewModels;
using PhoneApp.Views;
using System.Windows;

namespace DesignIdeTastyHouse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }

        private void MenuButton_Click(object sender, RoutedEventArgs e)
        {
            MenuPage mp = new();
            MainFrameWindow.Navigate(mp);
            Index.Visibility = Visibility.Hidden;
            MainFrameWindow.Visibility = Visibility.Visible;
        }

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            Index.Visibility = Visibility.Visible;
            MainFrameWindow.Visibility = Visibility.Hidden;
        }

        private void ContactButton_Click(object sender, RoutedEventArgs e)
        {
            ContactPage copa = new();
            MainFrameWindow.Navigate(copa);
            Index.Visibility = Visibility.Hidden;
            MainFrameWindow.Visibility= Visibility.Visible;
        }

        private void CartButton_Click(object sender, RoutedEventArgs e)
        {
            CartPage capa = new();
            MainFrameWindow.Navigate(capa);
            Index.Visibility = Visibility.Hidden;
            MainFrameWindow.Visibility = Visibility.Visible;
        }

        private void AccountButton_Click(object sender, RoutedEventArgs e)
        {
            AccountPage acpa = new();
            MainFrameWindow.Navigate(acpa);
            Index.Visibility = Visibility.Hidden;
            MainFrameWindow.Visibility = Visibility.Visible;
        }
    }
}