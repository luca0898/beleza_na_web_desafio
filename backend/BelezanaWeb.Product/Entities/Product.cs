using BelezanaWeb.Product.Entities.Shared;

namespace BelezanaWeb.Product.Entities
{
    public class Product : Entity
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public Inventory Inventory { get; set; }
        public bool IsMarketable
        {
            get { return Inventory.Quantity > 0; }
        }
    }
}
