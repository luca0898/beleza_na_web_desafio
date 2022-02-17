using System.Collections.Generic;

namespace BelezanaWeb.Product.ViewModel
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }
        public ICollection<WarehouseViewModel> Warehouses { get; set; }
    }

}
