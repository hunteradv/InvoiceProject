using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceProject.Class
{
    public class Address
    {
        public string AddressInfo { get; private set; }
        public int Number { get; private set; }
        public string District { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Country { get; private set; }
    }
}
