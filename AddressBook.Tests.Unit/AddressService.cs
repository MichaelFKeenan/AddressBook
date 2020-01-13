using System.Threading.Tasks;
using AddressBook.Services;
using NSubstitute;
using NUnit.Framework;
using System.IO;
using System.Linq;

namespace AddressBook.Tests.Unit
{
    public class AddressServiceTests
    {
        private AddressService _sut;

        private IJsonReader _jsonReader;

        [SetUp]
        public void Setup()
        {
            _jsonReader = Substitute.For<IJsonReader>();
            _sut = new AddressService(new JsonAddressRetriever(_jsonReader));
        }

        [Test]
        public async Task Given_MultipleCitiesProvided_When_GetAddressCityGroups_Then_ReturnCorrectAddressGroups()
        {
            _jsonReader.ReadAllTextAsync(Arg.Any<string>()).Returns(Task.FromResult(
                await File.ReadAllTextAsync("AddressesWithDifferentCities.json")
            ));

            var result = await _sut.GetAddressCityGroups();
            
            Assert.AreEqual(2, result.Single(x=>x.City == "city 1").Addresses.Count());
            Assert.AreEqual(1, result.Single(x=>x.City == "city 2").Addresses.Count());
        }

        [Test]
        public async Task Given_MultipleCitiesProvided_When_GetAddressCityGroups_Then_MapAddresses()
        {
            _jsonReader.ReadAllTextAsync(Arg.Any<string>()).Returns(Task.FromResult(
                await File.ReadAllTextAsync("AddressesWithDifferentCities.json")
            ));

            var result = await _sut.GetAddressCityGroups();
            
            var firstAddress = result.First().Addresses.First();

            Assert.AreEqual("first 1", firstAddress.FirstName);
            Assert.AreEqual("last 1", firstAddress.LastName);
            Assert.AreEqual("street 1", firstAddress.StreetAddress);
            Assert.AreEqual("city 1", firstAddress.City);
            Assert.AreEqual("country 1", firstAddress.Country);
        }

        [Test]
        public async Task Given_CitiesWithDifferentCasingProvided_When_GetAddressCityGroups_Then_ReturnCorrectAddresses()
        {
            _jsonReader.ReadAllTextAsync(Arg.Any<string>()).Returns(Task.FromResult(
                await File.ReadAllTextAsync("CitiesWithDifferentCasing.json")
            ));

            var result = await _sut.GetAddressCityGroups();
            
            Assert.AreEqual(2, result.First().Addresses.Count());
        }
    }
}