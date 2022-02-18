using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BelezanaWeb.Product.InputModel
{
    public class ProductInputModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryInputModel Inventory { get; set; }
    }

}
