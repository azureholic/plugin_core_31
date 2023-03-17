using System;
using System.Collections.Generic;
using System.Text;

namespace SharedDomain {
    public interface ICustomerService {
        Customer GetCustomer(int Id);
    }
}
