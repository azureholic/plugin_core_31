using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedDomain;
using System;

namespace CustomerPlugin {

    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase {
        private readonly ILogger _logger;

        public CustomerController(ILogger<CustomerController> logger) {
            _logger = logger;
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult GetCustomer(int Id) {
            Customer customer = new Customer();
            customer.Id = Id;
            customer.Name = "Lely";
            return Ok(customer);
        }

        [HttpGet]
        public IActionResult ShowVersion() {
            var newtonSoftJsonType = typeof(Newtonsoft.Json.JsonConvert).Assembly;
            return Ok("This plugin uses " + newtonSoftJsonType.GetName().ToString());

        }

    }
}
