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
            var filterBuilder = Builders<Product.Entities.Product>.Filter;

            FilterDefinition<Product.Entities.Product> filter = filterBuilder.And(
                filterBuilder.Eq(nameof(Product.Entities.Product.Sku), sku),
                filterBuilder.Eq(nameof(Product.Entities.Product.Deleted), false)
            );

            IAsyncCursor<Product.Entities.Product> query = await _mongoCollection.FindAsync(filter, null, cancellationToken);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
