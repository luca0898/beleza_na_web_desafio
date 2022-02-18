namespace BelezanaWeb.Domain.ViewModels
{
    public class ProductViewModel
    {
        public int Sku { get; set; }
        public string Name { get; set; }
        public InventoryViewModel Inventory { get; set; }
        public bool IsMarketable { get; set; }
    }

}
