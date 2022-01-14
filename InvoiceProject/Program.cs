using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceProject.Class;
using InvoiceProject.Enum;

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
                    2,
                    1,
                    new List<Payment> { new Payment {Id = 2 ,PaymentValue = 6, PaymentDescription = "Crédito Stone" } },
                    new List<Item>()
                    )};

                //var running = true;
                //var destinataires = new List<Client>
                //{
                //    new Client
                //    {
                //        Id = 3,
                //        Name = "Client",
                //        LastName = "3",
                //        Gender = "Female",
                //        Contacts = new List<Contact> {new Contact { Id = 2, ContactType = "telefone", ContactInfo = "1111111111" } },
                //        Addresses = new List<Address> { new Address { Street = "Rua teste 2", City = "Cidade teste 1", Country = "País teste 1", District = "Bairro teste 1", Number = 111, State = "SA" } }
                //    }
                //};
                //do
                //{
                //    int choice;
                //    Console.WriteLine("Digite o id da nota: ");
                //    var invoiceId = int.Parse(Console.ReadLine());
                //    var invoice = invoices.FirstOrDefault(x => x.Id == invoiceId);

                //    Console.WriteLine();
                //    Console.WriteLine($"Id da nota: {invoice.Id} ");
                //    Console.WriteLine($"Nome do destinatário: {invoice.Destinatary.Name} {invoice.Destinatary.LastName} ");
                //    Console.WriteLine($"Gender: {invoice.Destinatary.Gender}");
                //    Console.WriteLine($"Number: {invoice.Number}");
                //    Console.WriteLine($"Número de série: {invoice.SerialNumber}");
                //    Console.WriteLine($"Amount: {invoice.Amount}");
                //    Console.WriteLine($"Valor pagamentos: {invoice.Payments.FirstOrDefault().PaymentValue}");
                //    Console.WriteLine($"Status invoice: {invoice.Status}");
                //    Console.WriteLine();

                //    Console.WriteLine("Menu de operações: \n0- Sair\n1-Alterar Nota \n2- Excluir Nota\n3-Itens da nota");
                //    choice = int.Parse(Console.ReadLine());

                //    switch (choice)
                //    {
                //        case 0: 
                //            running = false;
                //            break;
                //        case 1:
                //            InvoiceDto invoiceDto = new InvoiceDto();
                //            Console.WriteLine(": ");
                //    }

                //} while (running);   

                var invoice = invoices.FirstOrDefault(x => x.Id == 1);

                invoice = Item.CreateItem(invoice, 2, "Água com gás", 5, 2, 10);

                var invoice2 = invoices.FirstOrDefault(x => x.Id == 2);

                invoice2 = Item.CreateItem(invoice2, 2, "Água s/ gás", 3, 2, 6);

                Console.WriteLine($"Digite o número a seguir para escolher o status da nota {invoice.Id}");
                Console.WriteLine("1- Erro \n2- Pendente \n3-Enviado");
                var status = int.Parse(Console.ReadLine());

                invoice = Invoice.AlterStatusInvoice(invoice, (InvoiceStatusEnum)status);


                Console.WriteLine($"Id da nota: {invoice.Id} ");
                Console.WriteLine($"Nome do destinatário: {invoice.Destinatary.Name} {invoice.Destinatary.LastName} ");
                Console.WriteLine($"Gender: {invoice.Destinatary.Gender}");
                Console.WriteLine($"Number: {invoice.Number}");
                Console.WriteLine($"Número de série: {invoice.SerialNumber}");
                Console.WriteLine($"Amount: {invoice.Amount}");
                Console.WriteLine($"Valor pagamentos: {invoice.Payments.FirstOrDefault().PaymentValue}");
                Console.WriteLine($"Status invoice: {invoice.Status}");
                Console.WriteLine();

                Console.WriteLine($"Id da nota: {invoice2.Id} ");
                Console.WriteLine($"Nome do destinatário: {invoice2.Destinatary.Name} {invoice2.Destinatary.LastName} ");
                Console.WriteLine($"Gender: {invoice2.Destinatary.Gender}");
                Console.WriteLine($"Number: {invoice2.Number}");
                Console.WriteLine($"Número de série: {invoice2.SerialNumber}");
                Console.WriteLine($"Amount: {invoice2.Amount}");
                Console.WriteLine($"Valor pagamentos: {invoice2.Payments.FirstOrDefault().PaymentValue}");
                Console.WriteLine($"Status invoice: {invoice2.Status}");
                Console.WriteLine();


                foreach (var items in invoice.Items)
                {
                    Console.WriteLine($"Lista de id dos itens: {items.IdItem}");
                }

                Console.WriteLine();

                foreach (var item in invoice.Items)
                {
                    Console.WriteLine($"Id da invoice a que o item se refere: {invoice.Id}");
                    Console.WriteLine($"Id do item: {item.IdItem}");
                    Console.WriteLine($"Id do produto: {item.ProductId}");
                    Console.WriteLine($"Descrição: {item.DescriptionProduct}");
                    Console.WriteLine($"Valor unitário: {item.UnitValue}");
                    Console.WriteLine($"Quantidade: {item.Quantity}");
                    Console.WriteLine($"Valor total: {item.TotalProduct}");
                    Console.WriteLine();
                }

                foreach (var item in invoice2.Items)
                {
                    Console.WriteLine($"Id da invoice a que o item se refere: {invoice2.Id}");
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

                invoices = Invoice.DeleteInvoice(invoices, 2);

                Console.WriteLine();

                Console.WriteLine($"Quantidade de produtos da nota a ser excluido: {invoice.Items.Count} ");
                Console.WriteLine("Excluindo item");
                invoice = Item.DeleteItem(invoice, 2);
                Console.WriteLine($"Quantidade de produtos da nota a ser excluido: {invoice.Items.Count} ");

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
