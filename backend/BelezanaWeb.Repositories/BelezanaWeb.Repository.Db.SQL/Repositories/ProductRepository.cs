using BelezanaWeb.Db.SQL.Repositories.Shared;
using BelezanaWeb.Product.Contracts.Repositories;
using MongoDB.Driver;

namespace BelezanaWeb.Db.SQL.Repositories
{
    public class ProductRepository : GenericNonRelationalRepository<Product.Entities.Product>, IProductRepository
    {
        private const string CollectionName = "Products";

        public ProductRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase, CollectionName)
        {
        }
    }
}
