using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedDomain;
using System;
using System.Runtime.InteropServices;

namespace OrderPlugIn {
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase {
        private readonly ILogger _logger;

        public OrderController(ILogger<OrderController> logger) {
            _logger = logger;
        }

        [HttpGet]
        [Route("{OrderId}")]
        public IActionResult GetOrder(int OrderId) {
            Customer customer = new Customer();
            customer.Id = 1;
            customer.Name = "Lely";

            Order order = new Order();
            order.OrderNr = OrderId;
            order.Customer = customer;

            return Ok(order);
        }

        [HttpGet]
        public IActionResult ShowVersion() {
            var newtonSoftJsonType = typeof(Newtonsoft.Json.JsonConvert).Assembly;
            return Ok("This plugin uses " + newtonSoftJsonType.GetName().ToString());

        }

    }
}
