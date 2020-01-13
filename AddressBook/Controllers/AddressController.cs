using System;
using System.Threading.Tasks;
using AddressBook.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AddressBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;
        private ILogger<AddressController> _logger;

        public AddressController(IAddressService addressService, ILogger<AddressController> logger)
        {
            _addressService = addressService;
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetAddressCityGroups()
        {
            try
            {
                var result = await _addressService.GetAddressCityGroups();
                return Ok(result);
            }
            catch (Exception ex)
            {
                //bare minimum error handling
                _logger.LogError(ex.Message);
                return StatusCode(500);
            }
        }
    }
}
