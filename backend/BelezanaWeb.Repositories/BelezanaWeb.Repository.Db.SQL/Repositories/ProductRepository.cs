using BelezanaWeb.Db.SQL.Repositories.Shared;
using BelezanaWeb.Domain.Contracts.Repositories;
using BelezanaWeb.Domain.Entities;
using MongoDB.Driver;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Db.SQL.Repositories
{
    public class ProductRepository : GenericNonRelationalRepository<Product>, IProductRepository
    {
        private const string CollectionName = "Products";

        public ProductRepository(IMongoDatabase mongoDatabase) : base(mongoDatabase, CollectionName)
        {
        }

        public async Task<Product> GetBySkuAsync(int sku, CancellationToken cancellationToken = default)
        {
            var filterBuilder = Builders<Product>.Filter;

            FilterDefinition<Product> filter = filterBuilder.And(
                filterBuilder.Eq(nameof(Product.Sku), sku),
                filterBuilder.Eq(nameof(Product.Deleted), false)
            );

            IAsyncCursor<Product> query = await _mongoCollection.FindAsync(filter, null, cancellationToken);

            return await query.FirstOrDefaultAsync(cancellationToken);
        }
    }
}
