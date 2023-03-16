using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedDomain;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Runtime.InteropServices;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace OrderPlugIn {
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase {
        private readonly ILogger _logger;
        private readonly string _baseAddress = "https://localhost:5001";

        public OrderController(ILogger<OrderController> logger) {
            _logger = logger;
        }

        [HttpGet]
        [Route("{OrderId}")]
        public async Task<IActionResult> GetOrder(int OrderId) {
            

            Order order = new Order();
            order.OrderNr = OrderId;
            _logger.LogInformation("Getting customer for order {OrderId}", OrderId);
            order.Customer = await GetCustomer(OrderId);

            return Ok(order);
        }

        [HttpGet]
        public IActionResult ShowVersion() {
            var newtonSoftJsonType = typeof(Newtonsoft.Json.JsonConvert).Assembly;
            return Ok("This plugin uses " + newtonSoftJsonType.GetName().ToString());

        }


        private async Task<Customer> GetCustomer(int Id) {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(_baseAddress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = client.GetAsync($"/customer/{Id}").Result;

                string json = await response.Content.ReadAsStringAsync();
                Customer customer = JsonConvert.DeserializeObject<Customer>(json);
                return customer;
            }
        }

    }
}
