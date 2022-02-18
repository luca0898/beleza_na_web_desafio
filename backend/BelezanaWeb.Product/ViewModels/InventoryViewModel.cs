using System.Collections.Generic;

namespace BelezanaWeb.Domain.ViewModels
{
    public class InventoryViewModel
    {
        public int Quantity { get; set; }
        public ICollection<WarehouseViewModel> Warehouses { get; set; }
    }
}
