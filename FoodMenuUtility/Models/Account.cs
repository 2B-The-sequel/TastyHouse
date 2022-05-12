namespace FoodMenuUtility.Models
{
    public class Account
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public long PhoneNumber { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public string City { get; set; }

        public Account(string Email, string Password, long PhoneNumber,
            string FirstName, string LastName, string Address, int ZipCode, string City)
        {
            this.Email = Email;
            this.Password = Password;
            this.PhoneNumber = PhoneNumber;

            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Address = Address;
            this.ZipCode = ZipCode;
            this.City = City;
        }
    }
}