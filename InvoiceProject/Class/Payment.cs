using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceProject.Class
{
    public class Payment
    {
        public int Id { get; private set; }
        public string PaymentDescription { get; private set; }
        public double PaymentValue { get; set; }
    }
}
