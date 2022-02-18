using System.Collections.Generic;

namespace BelezanaWeb.Domain.InputModel
{
    public class InventoryInputModel
    {
        public ICollection<WarehouseInputModel> Warehouses { get; set; }
    }

}
