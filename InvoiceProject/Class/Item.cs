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
        public int ProductId { get; private set; }
        public string DescriptionProduct { get; private set; }
        public decimal UnitValue { get; private set; }
        public int Quantity { get; private set; }
        public decimal TotalProduct { get; private set; }
        

        //public Item(int _productId, string _description, decimal _unitValue, int _quantity, decimal _totalProduct)
        //{
        //    ProductId = _productId;
        //    DescriptionProduct = _description; 
        //    UnitValue = _unitValue;
        //    Quantity = _quantity;
        //    TotalProduct = _totalProduct;
        //}

        //public Item CreateItem(int _productId, string _description, decimal _unitValue, int _quantity, decimal _totalProduct)
        //{
        //    var Item = new Item(_productId, _description, _unitValue, _quantity, _totalProduct);

        //    return Item;
        //}
    }
}
