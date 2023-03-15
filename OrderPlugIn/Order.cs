using SharedDomain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderPlugIn {
    public class Order {
        public int OrderNr { get; set; }
        public Customer Customer{ get; set; }
    }
}
