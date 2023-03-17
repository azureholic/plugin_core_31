using SharedDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerPlugin {
    public class CustomerService : ICustomerService {
        public Customer GetCustomer(int Id) {
            Customer customer = new Customer();
            customer.Id = Id;
            customer.Name = "Lely";
            return customer;
        }
    }
}
