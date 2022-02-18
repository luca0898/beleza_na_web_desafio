using BelezanaWeb.Product.Contracts.Repositories.Shared;
using BelezanaWeb.Product.Contracts.Services.Shared;
using BelezanaWeb.Product.Contracts.Shared;
using BelezanaWeb.SystemObjects.Exceptions;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Services.Shared
{
    public abstract class GenericEntityService<TEntity> : IGenericEntityService<TEntity> where TEntity : class, IEntity
    {
        protected readonly IGenericRepository<TEntity> _repository;

        public GenericEntityService(IGenericRepository<TEntity> TEntityRepository)
        {
            _repository = TEntityRepository;
        }

        public virtual IEnumerable<TEntity> FindAll(int skip = 0, int take = 20)
        {
            return _repository.FindAll(skip, take);
        }

        public virtual TEntity GetOneAsync(string id, CancellationToken cancellationToken = default)
        {
            return _repository.FindOne(id);
        }

        public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _repository.CreateAsync(entity, cancellationToken);
        }

        public virtual async Task UpdateAsync(string id, TEntity modifiedEntity, CancellationToken cancellationToken = default)
        {
            TEntity entity = _repository.FindOne(id);

            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                await _repository.Update(modifiedEntity, cancellationToken);
            }
            else
            {
                string message = $"{typeof(TEntity).Name} {id} not found";
                throw new BelezanaWebApplicationException(message, HttpStatusCode.NotFound);
            }
        }

        public virtual async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            TEntity entity = _repository.FindOne(id);

            if (entity != null && !string.IsNullOrEmpty(entity.Id))
            {
                await _repository.SoftDelete(entity, cancellationToken);
            }
            else
            {
                string message = $"{typeof(TEntity).Name} {id} not found";
                throw new BelezanaWebApplicationException(message, HttpStatusCode.NotFound);
            }
        }
    }
}
