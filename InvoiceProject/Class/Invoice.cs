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
        public decimal Amount => Items.Select(x => x.TotalProduct).DefaultIfEmpty(0).Sum();
        public List<Payment> Payments { get; protected set; }
        public List<Item> Items { get; protected set; }

        private Invoice(int _id, Client _destinatary, int _number, int _serialNumber, List<Payment> _payments, List<Item> _items)
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
            if(_payments == null || _payments.Count == 0)
            {
                throw new ArgumentException("Lista de pagamentos está nula ou vazia");
            }

            Id = _id;
            Destinatary = _destinatary;
            Number = _number;
            SerialNumber = _serialNumber;
            Payments = _payments;
            Items = _items;
            Status = InvoiceStatusEnum.Pendente;
        }

        public static Invoice CreateInvoice(int _id, Client _destinatary, int _number, int _serialNumber, List<Payment> _payments, List<Item> _items)
        {
            return new Invoice(_id, _destinatary, _number, _serialNumber, _payments, _items);
        }

        public static Invoice AlterInvoice(Invoice invoice,InvoiceDto data)
        {
            if(data.Destinatary != null && data.Destinatary != invoice.Destinatary)
            {
                invoice.Destinatary = data.Destinatary;
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

        //usuário escolhe o status, adicionar opções
        public static Invoice AlterStatusInvoice(Invoice invoice, InvoiceStatusEnum invoiceStatusEnum)
        {
            invoice.Status = invoiceStatusEnum;

            return invoice;
        }

        //excluir nota somente quando pendente ou com erro
        public static List<Invoice> DeleteInvoice(List<Invoice> invoices, int Id)
        {
            var invoice = invoices.Where(x => x.Id == Id).FirstOrDefault();
            if(invoice != null)
            {
                if (invoice.Status != InvoiceStatusEnum.Enviado)
                {
                    var isRemoved = invoices.Remove(invoice);
                    if (isRemoved)
                    {
                        return invoices;
                    }
                }
                throw new Exception("Não foi possível excluir a nota pois o status atual é 'Enviado'.");
            }
            throw new Exception($"Não foi possível localizar e remover a nota com id {Id}");
        }
    }
}