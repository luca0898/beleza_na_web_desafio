using BelezanaWeb.Product.Contracts.Repositories.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Product.Contracts.Repositories
{
    public interface IProductRepository : IGenericRepository<Entities.Product>
    {
        Task<Entities.Product> GetBySkuAsync(int sku, CancellationToken cancellationToken = default);
    }
}
