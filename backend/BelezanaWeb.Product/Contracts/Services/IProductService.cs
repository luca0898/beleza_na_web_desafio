using BelezanaWeb.Domain.Contracts.Services.Shared;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Domain.Contracts.Services
{
    public interface IProductService : IGenericEntityService<Entities.Product>
    {
        Task DeleteBySkuAsync(int sku, CancellationToken cancellationToken = default);
        Task<Entities.Product> GetBySkuAsync(int sku, CancellationToken cancellationToken = default);
        Task UpdateBySkuAsync(int sku, Entities.Product modifiedEntity, CancellationToken cancellationToken = default);
    }
}
