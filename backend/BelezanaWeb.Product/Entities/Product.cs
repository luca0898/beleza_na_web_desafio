using BelezanaWeb.Domain.Entities.Shared;

namespace BelezanaWeb.Domain.Entities
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
