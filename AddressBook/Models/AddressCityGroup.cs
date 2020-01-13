using System.Collections.Generic;
using System.Linq;

namespace AddressBook.Models
{
    public class AddressCityGroup
    {
        public AddressCityGroup(string city, List<Address> addresses)
        {
            City = city;
            Addresses = addresses;
        }
        public string City { get; }
        public List<Address> Addresses { get; }
    }
}