using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceProject.Class
{
    public class ItemDto
    { 
        public int ProductId { get; set; }
        public string DescriptionProduct { get; set; }
        public decimal UnitValue { get; set; }
        public int Quantity { get; set; }
        public decimal TotalProduct { get; set; }
    }
}
