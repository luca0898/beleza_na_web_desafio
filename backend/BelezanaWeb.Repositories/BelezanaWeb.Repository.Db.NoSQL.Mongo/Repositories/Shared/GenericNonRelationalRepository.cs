using BelezanaWeb.Domain.Contracts.Repositories.Shared;
using BelezanaWeb.Domain.Contracts.Shared;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Db.NoSQL.Mongo.Repositories.Shared
{
    public abstract class GenericNonRelationalRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly IMongoDatabase _mongoDatabase;
        protected IMongoCollection<TEntity> _mongoCollection;

        protected GenericNonRelationalRepository(IMongoDatabase mongoDatabase, string collectionName)
        {
            _mongoDatabase = mongoDatabase;
            _mongoCollection = _mongoDatabase.GetCollection<TEntity>(collectionName);
        }

        public virtual async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _mongoCollection.InsertOneAsync(entity, null, cancellationToken);
        }

        public virtual IEnumerable<TEntity> FindAll(int skip = 0, int take = 20)
        {
            return _mongoCollection
                .AsQueryable()
                .Where(schedule => schedule.Deleted == false)
                .OrderBy(schedule => schedule.Id)
                .Skip(skip)
                .Take(take)
                .ToList();
        }

        public virtual TEntity FindOne(string id, CancellationToken cancellationToken = default)
        {
            return _mongoCollection
                .AsQueryable()
                .FirstOrDefault((entity) => entity.Id == id);
        }

        public virtual async Task HardDelete(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _mongoCollection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("Id", entity.Id), new DeleteOptions { }, cancellationToken);
        }

        public virtual async Task SoftDelete(TEntity entity, CancellationToken cancellationToken = default)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", entity.Id);
            var update = Builders<TEntity>.Update.Set("Deleted", false);

            await _mongoCollection.UpdateOneAsync(filter, update, null, cancellationToken);
        }

        public virtual async Task Update(TEntity entity, CancellationToken cancellationToken = default)
        {
            await _mongoCollection.ReplaceOneAsync(
                Builders<TEntity>.Filter.Eq("Id", entity.Id),
                entity,
                new ReplaceOptions
                {
                    BypassDocumentValidation = false,
                    IsUpsert = false,
                },
                cancellationToken);
        }
    }
}
