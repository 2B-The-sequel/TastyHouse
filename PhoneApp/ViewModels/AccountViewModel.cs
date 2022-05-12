using FoodMenuUtility.Models;

namespace PhoneApp.ViewModels
{
    public class AccountViewModel : ViewModel<Account>
    {
        public string Email
        {
            get
            {
                return model.Email;
            }
            set
            {
                model.Email = value;
            }
        }

        public string Password
        {
            get
            {
                return model.Password;
            }
            set
            {
                model.Password = value;
            }
        }

        public long PhoneNumber
        {
            get
            {
                return model.PhoneNumber;
            }
            set
            {
                model.PhoneNumber = value;
            }
        }

        public string FirstName
        {
            get
            {
                return model.FirstName;
            }
            set
            {
                model.FirstName = value;
            }
        }

        public string LastName
        {
            get
            {
                return model.LastName;
            }
            set
            {
                model.LastName = value;
            }
        }

        public string Address
        {
            get
            {
                return model.Address;
            }
            set
            {
                model.Address = value;
            }
        }

        public int ZipCode
        {
            get
            {
                return model.ZipCode;
            }
            set
            {
                model.ZipCode = value;
            }
        }

        public string City
        {
            get
            {
                return model.City;
            }
            set
            {
                model.City = value;
            }
        }

        public AccountViewModel(Account model) : base(model) { }
    }
}