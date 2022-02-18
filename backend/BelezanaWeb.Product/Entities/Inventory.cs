using System.Collections.Generic;
using System.Linq;

namespace BelezanaWeb.Domain.Entities
{
    public class Inventory
    {
        public int Quantity
        {
            get { return Warehouses.Sum(w => w.Quantity); }
        }
        public ICollection<Warehouse> Warehouses { get; set; }
    }
}
