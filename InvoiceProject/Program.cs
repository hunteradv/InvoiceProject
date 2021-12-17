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
                var invoice = Invoice.CreateInvoice(1, new Client { Name = "Gustavo", LastName = "Henrique" }, 10, 100, new List<Payment> { new Payment { PaymentValue = 100 } }, new List<Item> { new Item { IdItem = 1 }, new Item { IdItem = 2 } });
                Console.WriteLine($"Id da nota: {invoice.Id} ");
                Console.WriteLine($"Nome do destinatário: {invoice.Destinatary.Name} {invoice.Destinatary.LastName} ");
                Console.WriteLine($"Número de série: {invoice.SerialNumber}");
                Console.WriteLine($"Valor: {invoice.Amount}");
                Console.WriteLine($"Valor pagamentos: {invoice.Payments.FirstOrDefault().PaymentValue}");
                foreach (var item in invoice.Items)
                {
                    Console.WriteLine($"Id dos itens: {item.IdItem}");
                }

                var invoice2 = Invoice.CreateInvoice(-1, new Client { Name = "Gustavo", LastName = "Henrique" }, 10, 100, new List<Payment> { new Payment { PaymentValue = 100 } }, new List<Item> { new Item { IdItem = 1 }, new Item { IdItem = 2 } });
              
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
