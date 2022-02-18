using System.Collections.Generic;

namespace BelezanaWeb.Product.InputModel
{
    public class InventoryInputModel
    {
        public ICollection<WarehouseInputModel> Warehouses { get; set; }
    }

}
