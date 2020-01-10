using System.Collections.Generic;
using System.Threading.Tasks;
using AddressBook.Controllers;
using AddressBook.Models;
using NUnit.Framework;

namespace AddressBook.Tests.Unit
{
    public class AddressControllerTests
    {
        private AddressController _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new AddressController();
        }

        [Test]
        public async Task When_GetRequest_ReturnListOfAddress()
        {
            var result = await _sut.GetAddresses();
            Assert.IsInstanceOf<List<Address>>( result );
        }
    }
}