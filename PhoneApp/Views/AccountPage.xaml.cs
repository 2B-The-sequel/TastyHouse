using PhoneApp.ViewModels;
using System.Windows.Controls;

namespace PhoneApp.Views
{
    /// <summary>
    /// Interaction logic for AccountPage.xaml
    /// </summary>
    public partial class AccountPage : Page
    {
        public AccountPage()
        {
            InitializeComponent();
            DataContext = MainViewModel.Instance;
        }
    }
}