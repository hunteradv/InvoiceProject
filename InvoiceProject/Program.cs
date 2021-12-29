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
                var invoice = Invoice.CreateInvoice(1,
                    new Client { Id = 1, Name = "Gustavo", LastName = "Henrique", Gender = "Male" },
                    1,
                    1,
                    15,
                    new List<Payment> { new Payment { PaymentValue = 100 } },
                    new List<Item> { Item.CreateItem(1, 1, "Agua", 3, 5, 15) }
                    );

                Console.WriteLine($"Id da nota: {invoice.Id} ");
                Console.WriteLine($"Nome do destinatário: {invoice.Destinatary.Name} {invoice.Destinatary.LastName} ");
                Console.WriteLine($"Gender: {invoice.Destinatary.Gender}");
                Console.WriteLine($"Number: {invoice.Number}");
                Console.WriteLine($"Número de série: {invoice.SerialNumber}");
                Console.WriteLine($"Amount: {invoice.Amount}");
                Console.WriteLine($"Valor pagamentos: {invoice.Payments.FirstOrDefault().PaymentValue}");
                foreach (var items in invoice.Items)
                {
                    Console.WriteLine($"Id dos itens: {items.IdItem}");
                }

                var item = Item.CreateItem(3, 2, "Água com gás", 5, 2, 10);

                Console.WriteLine($"Id do item: {item.IdItem}");
                Console.WriteLine($"Id do produto: {item.ProductId}");
                Console.WriteLine($"Descrição: {item.DescriptionProduct}");
                Console.WriteLine($"Valor unitário: {item.UnitValue}");
                Console.WriteLine($"Quantidade: {item.Quantity}");
                Console.WriteLine($"Valor total: {item.TotalProduct}");

                Console.WriteLine();

                invoice = Invoice.AlterInvoice(invoice, new InvoiceDto { Amount = 100000});
                Console.WriteLine($"Alterando Amount para 100000: {invoice.Amount}");

                invoice = Invoice.AlterStatusInvoice(invoice);
                Console.WriteLine($"Status invoice alterado: {invoice.Status}");

                invoice = Invoice.AlterInvoice(invoice, new InvoiceDto { Amount = 10 });
                Console.WriteLine($"Tentando alterando Amount para 10: {invoice.Amount}");

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
