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

        private Invoice(int _id, Client _destinatary, int _number, int _serialNumber, decimal _amount, List<Payment> _payments, List<Item> _items)
        {
            if (_id <= 0)
            {
                throw new ArgumentException("Id não pode ser menor ou igual a 0 (zero)");
            }
            if (_destinatary == null)
            {
                throw new ArgumentException("Destinatário não foi definido");
            }
            if(_number <= 0)
            {
                throw new ArgumentException("Número não pode ser menor ou igual a 0 (zero)");
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
            Number = _number;
            SerialNumber = _serialNumber;
            Amount = _amount;
            Payments = _payments;
            Items = _items;
            Status = InvoiceStatusEnum.Pendente;
        }

        public static Invoice CreateInvoice(int _id, Client _destinatary, int _number, int _serialNumber, decimal _amount, List<Payment> _payments, List<Item> _items)
        {
            return new Invoice(_id, _destinatary, _number, _serialNumber, _amount, _payments, _items);
        }

        public static Invoice AlterInvoice(Invoice invoice,InvoiceDto data)
        {
            if(invoice.Status == InvoiceStatusEnum.Enviado)
            {
                return invoice;
            }
            if(invoice.Status == InvoiceStatusEnum.Erro)
            {
                invoice.Status = InvoiceStatusEnum.Pendente;
            }
            if(data.Destinatary != null && data.Destinatary != invoice.Destinatary)
            {
                invoice.Destinatary = data.Destinatary;
            }
            if(data.Amount != default && data.Amount != invoice.Amount && data.Amount > 0)
            {
                invoice.Amount = data.Amount;
            }
            if(data.Number != default && data.Number != invoice.Number && data.Number > 0)
            {
                invoice.Number = data.Number;
            }
            if (data.SerialNumber != default && data.SerialNumber != invoice.SerialNumber && data.SerialNumber > 0)
            {
                invoice.SerialNumber = data.SerialNumber;
            }
            if (data.Payments != null && data.Payments != invoice.Payments)
            {
                invoice.Payments = data.Payments;
            }

            return invoice;
        }

        public static Invoice AlterStatusInvoice(Invoice invoice)
        {
            if(invoice.Status == InvoiceStatusEnum.Pendente)
            {
                invoice.Status = InvoiceStatusEnum.Enviado;
            }

            return invoice;
        }

        public static List<Invoice> DeleteInvoice(List<Invoice> invoices, int Id)
        {
            var invoice = invoices.Where(x => x.Id == Id).FirstOrDefault();
            var isRemoved = invoices.Remove(invoice); 
            if(isRemoved == true)
            {
                return invoices;
            }
            throw new Exception($"Não foi possível localizar e remover a nota com id {Id}");
        }
    }
}