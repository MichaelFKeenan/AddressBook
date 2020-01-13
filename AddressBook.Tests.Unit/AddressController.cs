using System.Threading.Tasks;
using AddressBook.Services;
using NSubstitute;
using NUnit.Framework;
using AddressBook.Controllers;
using System.Collections.Generic;
using AddressBook.Models;
using Microsoft.AspNetCore.Mvc;
using NSubstitute.ExceptionExtensions;
using System;
using Microsoft.Extensions.Logging;

namespace AddressBook.Tests.Unit
{
    public class AddressControllerTests
    {
        private AddressController _sut;

        private IAddressService _addressService;
        private ILogger<AddressController> _logger;

        [SetUp]
        public void Setup()
        {
            _addressService = Substitute.For<IAddressService>();
            _logger = Substitute.For<ILogger<AddressController>>();
            _sut = new AddressController(_addressService, _logger);
        }

        [Test]
        public async Task Given_AddressServiceSuccess_When_GetAddressCityGroups_Then_ReturnSuccessWithData()
        {
            _addressService.GetAddressCityGroups().Returns(Task.FromResult(
                new List<AddressCityGroup>()
            ));

            var result = await _sut.GetAddressCityGroups() as ObjectResult;

            Assert.True(result.StatusCode == 200);
            Assert.IsInstanceOf<List<AddressCityGroup>>(result.Value);
        }

        // should really have one assert per test but run out of time!
        [Test]
        public async Task Given_AddressServiceFails_When_GetAddressCityGroups_Then_ReturnErrorAndLogMessage()
        {
            var serviceExceptionMessage = "some error";
            _addressService.GetAddressCityGroups().Throws(new Exception(serviceExceptionMessage));

            var result = await _sut.GetAddressCityGroups() as ObjectResult;

            Assert.True(result.StatusCode == 500);
            _logger.Received().LogError(serviceExceptionMessage);
        }
    }
}