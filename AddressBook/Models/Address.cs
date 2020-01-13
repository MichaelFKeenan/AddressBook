namespace AddressBook.Models
{
    public class Address
    {
        public Address(string firstName, string lastName, string streetAddress, string city, string country)
        {
            FirstName = firstName;
            LastName = lastName;
            StreetAddress = streetAddress;
            City = city;
            Country = country;
        }
        public string FirstName { get; }
        public string LastName { get; }
        public string StreetAddress { get; }
        public string City { get; }
        public string Country { get; }
    }
}