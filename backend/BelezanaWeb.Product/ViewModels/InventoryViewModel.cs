using System.Collections.Generic;

namespace BelezanaWeb.Product.ViewModels
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }
        public ICollection<WarehouseViewModel> Warehouses { get; set; }
    }
}
