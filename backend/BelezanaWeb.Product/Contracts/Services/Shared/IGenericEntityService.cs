using BelezanaWeb.Domain.Contracts.Shared;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Domain.Contracts.Services.Shared
{
    public interface IGenericEntityService<TEntity> where TEntity : IEntity
    {
        IEnumerable<TEntity> FindAll(int skip = 0, int take = 20);
        TEntity GetOneAsync(string id, CancellationToken cancellationToken = default);
        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task UpdateAsync(string id, TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(string id, CancellationToken cancellationToken = default);
    }
}
