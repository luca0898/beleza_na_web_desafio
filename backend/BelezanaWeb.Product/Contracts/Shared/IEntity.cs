namespace BelezanaWeb.Product.Contracts.Shared
{
    public interface IEntity
    {
        string Id { get; set; }
        bool Deleted { get; set; }
    }
}
