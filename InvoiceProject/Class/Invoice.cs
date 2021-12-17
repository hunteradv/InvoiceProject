using InvoiceProject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceProject.Class
{
    public class Invoice
    {
        public int Id { get; set; }
        public InvoiceStatusEnum Status { get; private set; }
        public Client Destinatary { get; set; }
        public int SerialNumber { get; private set; }
        public int Number { get; private set; }
        public decimal Amount { get; private set; }
        public List<Payment> Payments { get; protected set; }
        public List<Item> Items { get; protected set; }

        private Invoice(int _id, Client _destinatary, int _serialNumber, decimal _amount, List<Payment> _payments, List<Item> _items)
        {
            if (_id <= 0)
            {
                throw new ArgumentException("Id não pode ser menor ou igual a 0 (zero)");
            }
            if (_destinatary == null)
            {
                throw new ArgumentException("O destinatário não foi definido");
            }
            if(_serialNumber <= 0)
            {
                throw new ArgumentException("Número de série não pode ser menor ou igual a 0 (zero)");
            }
            if(_amount <= 0)
            {
                throw new ArgumentException("Valor não pode ser menor ou igual a 0 (zero)");
            }
            if(_payments == null || _payments.Count == 0)
            {
                throw new ArgumentException("Lista de pagamentos está nula ou vazia");
            }
            if (_items == null || _items.Count == 0)
            {
                throw new ArgumentException("Lista de itens está nula ou vazia");
            }

            Id = _id;
            Destinatary = _destinatary;
            SerialNumber = _serialNumber;
            Amount = _amount;
            Payments = _payments;
            Items = _items;
            Status = InvoiceStatusEnum.Pendente;
        }

        public static Invoice CreateInvoice(int _id, Client _destinatary, int _serialNumber, decimal _amount, List<Payment> _payments, List<Item> _items)
        {
            return new Invoice(_id, _destinatary, _serialNumber, _amount, _payments, _items);
        }
    }
}