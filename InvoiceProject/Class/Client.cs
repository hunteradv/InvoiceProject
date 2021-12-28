using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceProject.Class
{
    public class Client
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Gender { get; private set; }
        public List<Address> Addresses { get; protected set; }
        public List<Contact> Contacts { get; protected set; }
    }
}
