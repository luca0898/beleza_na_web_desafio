using BelezanaWeb.Product.Entities.Shared;

namespace BelezanaWeb.Product.Entities
{
    public class Warehouse
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Inventory Inventory { get; set; }
    }
}
