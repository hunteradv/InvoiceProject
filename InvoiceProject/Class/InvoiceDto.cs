using InvoiceProject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceProject.Class
{
    public class InvoiceDto
    {
        public InvoiceStatusEnum Status { get; set; }
        public Client Destinatary { get; set; }
        public int SerialNumber { get; set; }
        public int Number { get; set; }
        public decimal Amount { get; set; }
        public List<Payment> Payments { get; set; }
    }
}
