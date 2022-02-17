using BelezanaWeb.Product.Entities.Shared;

namespace BelezanaWeb.Product.Entities
{
    public class Warehouse : Entity
    {
        public string Locality { get; set; }
        public int Quantity { get; set; }
        public string Type { get; set; }

        public Inventory Inventory { get; set; }
    }
}
