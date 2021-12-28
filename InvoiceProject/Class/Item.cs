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
        public int Quantity { get; set; }
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

        public static Item CreateItem(int _idItem, int _productId, string _description, decimal _unitValue, int _quantity, decimal _totalProduct)
        {
            return new Item(_idItem, _productId, _description, _unitValue, _quantity, _totalProduct);
        }

    }
}
