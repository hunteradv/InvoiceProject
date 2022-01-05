using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceProject.Class;

namespace InvoiceProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var invoices = new List<Invoice> { Invoice.CreateInvoice(1,
                    new Client
                    {
                        Id = 1,
                        Name = "Gustavo",
                        LastName = "Henrique",
                        Gender = "Male",
                        Contacts = new List<Contact> { new Contact { Id = 1, ContactType = "e-mail", ContactInfo = "gustavopaulody@gmail.com" }, new Contact { Id = 2, ContactInfo = "123456678", ContactType = "telefone" } },
                        Addresses = new List<Address> { new Address { Street = "Rua teste", City = "Potirendaba", Country = "Brasil", District = "Bairro teste", Number = 180, State = "SP" } }
                    },
                    1,
                    1,
                    10,
                    new List<Payment> { new Payment { Id = 1 ,PaymentValue = 10, PaymentDescription = "Dinheiro" } },
                    new List<Item>()
                    ),

                    Invoice.CreateInvoice(2,
                    new Client
                    {
                        Id = 2,
                        Name = "Peter",
                        LastName = "Parker",
                        Gender = "Male",
                        Contacts = new List<Contact> {new Contact { Id = 2, ContactType = "telefone", ContactInfo = "112345656" } },
                        Addresses = new List<Address> { new Address { Street = "Rua teste 1", City = "Nova Iorque", Country = "Estados Unidos", District = "Bairro teste 1", Number = 180, State = "NI" } }
                    },
                    1,
                    1,
                    6,
                    new List<Payment> { new Payment {Id = 2 ,PaymentValue = 6, PaymentDescription = "Crédito Stone" } },
                    new List<Item>()
                    )};

                var invoice = invoices.FirstOrDefault(x => x.Id == 1);

                invoice = Item.CreateItem(invoice, 2, "Água com gás", 5, 2, 10);

                var invoice2 = invoices.FirstOrDefault(x => x.Id == 2);

                invoice2 = Item.CreateItem(invoice, 2, "Água s/ gás", 3, 2, 6);
                
                Console.WriteLine($"Id da nota: {invoice.Id} ");
                Console.WriteLine($"Nome do destinatário: {invoice.Destinatary.Name} {invoice.Destinatary.LastName} ");
                Console.WriteLine($"Gender: {invoice.Destinatary.Gender}");
                Console.WriteLine($"Number: {invoice.Number}");
                Console.WriteLine($"Número de série: {invoice.SerialNumber}");
                Console.WriteLine($"Amount: {invoice.Amount}");
                Console.WriteLine($"Valor pagamentos: {invoice.Payments.FirstOrDefault().PaymentValue}");
                Console.WriteLine();

                foreach (var items in invoice.Items)
                {
                    Console.WriteLine($"Lista de id dos itens: {items.IdItem}");
                }

                Console.WriteLine();

                invoice = Invoice.AlterInvoice(invoice, new InvoiceDto { Amount = 100000 });
                Console.WriteLine($"Alterando Amount para 100000: {invoice.Amount}");

                invoice = Invoice.AlterStatusInvoice(invoice);
                Console.WriteLine($"Status invoice alterado: {invoice.Status}");

                invoice = Invoice.AlterInvoice(invoice, new InvoiceDto { Amount = 10 });
                Console.WriteLine($"Tentando alterando Amount para 10: {invoice.Amount}");

                Console.WriteLine();

                foreach (var item in invoice.Items)
                {
                    Console.WriteLine($"Id do item: {item.IdItem}");
                    Console.WriteLine($"Id do produto: {item.ProductId}");
                    Console.WriteLine($"Descrição: {item.DescriptionProduct}");
                    Console.WriteLine($"Valor unitário: {item.UnitValue}");
                    Console.WriteLine($"Quantidade: {item.Quantity}");
                    Console.WriteLine($"Valor total: {item.TotalProduct}");
                    Console.WriteLine();
                }

                Console.WriteLine();

                invoice = Item.AlterItem(invoice, new ItemDto { ProductId = 2, DescriptionProduct = "Água c/ gás" });
                var itemUpdate = invoice.Items.FirstOrDefault(x => x.ProductId == 2);
                Console.WriteLine($"Alterando DescriptionProduct: {itemUpdate.DescriptionProduct}");

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine($"Tamanho da lista de notas: {invoices.Count}");
                foreach (var inv in invoices)
                {
                    Console.WriteLine($"Lista de id das notas: {inv.Id}");
                }

                Console.WriteLine();

                invoices = Invoice.DeleteInvoice(invoices, 3);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Aconteceu um erro: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Aconteceu um erro inesperado: {ex.Message}");
            }


        }
    }
}
