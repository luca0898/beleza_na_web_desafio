namespace BelezanaWeb.Domain.InputModel
{
    public class ProductInputModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryInputModel Inventory { get; set; }
    }

}
