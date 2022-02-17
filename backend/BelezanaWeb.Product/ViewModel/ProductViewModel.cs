using System;
using System.ComponentModel;
using System.Runtime.Serialization;

namespace BelezanaWeb.Product.ViewModel
{
    public class ProductViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }

}
