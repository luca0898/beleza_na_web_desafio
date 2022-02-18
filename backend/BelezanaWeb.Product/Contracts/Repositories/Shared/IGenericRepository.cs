using BelezanaWeb.Product.Contracts.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Product.Contracts.Repositories.Shared
{
    public interface IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        IEnumerable<TEntity> FindAll(int skip = 0, int take = 20);
        TEntity FindOne(string id, CancellationToken cancellationToken = default);
        Task HardDelete(TEntity entity, CancellationToken cancellationToken = default);
        Task SoftDelete(TEntity entity, CancellationToken cancellationToken = default);
        Task Update(TEntity entity, CancellationToken cancellationToken = default);
    }
}
