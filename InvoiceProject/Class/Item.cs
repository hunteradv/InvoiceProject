using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceProject.Class
{
    public class Item
    {
        public int IdItem { get; set; }
        public int ProductId { get; set; }
        public string DescriptionProduct { get; set; }
        public decimal UnitValue { get; set; }
        public decimal Quantity { get; set; }
        public decimal TotalProduct { get; set; }


        public Item(int _idItem, int _productId, string _description, decimal _unitValue, int _quantity, decimal _totalProduct)
        {
            if (_idItem < 1)
            {
                throw new ArgumentException("Id não pode ser menor ou igual a 0 (zero)");
            }
            if (_productId < 1)
            {
                throw new ArgumentException("Id do produto não pode ser menor ou igual a 0 (zero)");
            }
            if(_description == null)
            {
                throw new ArgumentException("Descrição do produto não pode ser nula");
            }
            if(_unitValue < 1)
            {
                throw new ArgumentException("Valor unitário não pode ser menor ou igual a 0 (zero)");
            }
            if (_quantity < 1)
            {
                throw new ArgumentException("Quantidade não pode ser menor ou igual a 0 (zero)");
            }
            if(_totalProduct < 1)
            {
                throw new ArgumentException("Valor total do produto não pode ser menor ou igual a 0 (zero)");
            }

            IdItem = _idItem;
            ProductId = _productId;
            DescriptionProduct = _description;
            UnitValue = _unitValue;
            Quantity = _quantity;
            TotalProduct = _totalProduct;
        }

        public static Invoice CreateItem(Invoice invoice, int _productId, string _description, decimal _unitValue, int _quantity, decimal _totalProduct)
        {
            var item = new Item(invoice.Id, _productId, _description, _unitValue, _quantity, _totalProduct);
            invoice.Items.Add(item);
            return invoice;
        }

        //valor unitario precisa ser >= 0
        //quantidade precisa ser >= 0
        //não trocar id do produto
        //adicionar ExcluiItem

        public static Invoice AlterItem(Invoice invoice, ItemDto data)
        {
            Item item = invoice.Items.FirstOrDefault(x => x.ProductId == data.ProductId);
            if(data.DescriptionProduct != null && data.DescriptionProduct != item.DescriptionProduct)
            {
                item.DescriptionProduct = data.DescriptionProduct;
            }
            if(data.UnitValue != default && data.UnitValue != item.UnitValue && data.UnitValue >=0)
            {
                item.UnitValue = data.UnitValue;
            }
            if(data.Quantity != default && data.Quantity != item.Quantity && data.Quantity >= 0)
            {
                item.Quantity = data.Quantity;
            }
            if(data.TotalProduct != default && data.Quantity != item.TotalProduct)
            {
                item.TotalProduct = data.TotalProduct;
            }

            return invoice;
        }

        public static Invoice DeleteItem(Invoice invoice, int Id)
        {
            var items = invoice.Items;

            if(items.Count == 1)
            {
                throw new Exception("Não é possível excluir o único item de uma nota, adicione um novo e posteriormente exclua este");
            }

            var item = items.Where(x => x.ProductId == Id).FirstOrDefault();
            var isRemoved = items.Remove(item);
            if(isRemoved)
            {
                return invoice;   
            }
            throw new Exception($"Não foi possível localizar e remover o item de ProductId {Id}");
        }
    }
}