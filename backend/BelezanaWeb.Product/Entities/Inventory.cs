using BelezanaWeb.Product.Entities.Shared;
using System.Collections.Generic;

namespace BelezanaWeb.Product.Entities
{
    public class Inventory : Entity
    {
        public int Quantity { get; set; }
        public ICollection<Warehouse> Warehouses { get; set; }

        public Product Product { get; set; }
    }
}
