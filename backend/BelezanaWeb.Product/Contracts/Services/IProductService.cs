using BelezanaWeb.Product.Contracts.Services.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Product.Contracts.Services
{
    public interface IProductService : IGenericEntityService<Entities.Product>
    {
        Task<Entities.Product> GetBySkuAsync(int sku, CancellationToken cancellationToken = default);
    }
}
