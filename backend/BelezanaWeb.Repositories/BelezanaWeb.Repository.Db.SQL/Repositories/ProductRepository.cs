using BelezanaWeb.Db.SQL.Repositories.Shared;
using BelezanaWeb.Product.Contracts.Repositories;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Db.SQL.Repositories
{
    public class ProductRepository : GenericNonRelationalRepository<Product.Entities.Product>, IProductRepository
    {
        private const string CollectionName = "Products";

        public ProductRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase, CollectionName)
        {
        }

        public async Task<Product.Entities.Product> GetBySkuAsync(int sku, CancellationToken cancellationToken = default)
        {
            FilterDefinition<Product.Entities.Product> filter = Builders<Product.Entities.Product>.Filter.Eq(nameof(Product.Entities.Product.Sku), sku);

            IAsyncCursor<Product.Entities.Product> query = await _mongoCollection.FindAsync(filter, null, cancellationToken);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
