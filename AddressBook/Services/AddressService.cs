using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AddressBook.Models;
using Newtonsoft.Json;

namespace AddressBook.Services
{
    public class AddressService : IAddressService
    {
        private IAddressRetriever _addressRetriever;

        public AddressService(IAddressRetriever addressRetriever)
        {
            _addressRetriever = addressRetriever;
        }

        public async Task<List<AddressCityGroup>> GetAddressCityGroups()
        {
            var addresses = await _addressRetriever.GetAll();

            var cityGroups = addresses.GroupBy(x => x.City, StringComparer.InvariantCultureIgnoreCase);

            return cityGroups.Select(cityGroup => new AddressCityGroup(cityGroup.Key, cityGroup.ToList())).ToList();
        }
    }
}