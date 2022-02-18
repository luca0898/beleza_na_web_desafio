using BelezanaWeb.Domain.Contracts.Repositories;
using BelezanaWeb.Domain.Contracts.Services;
using BelezanaWeb.Domain.Entities;
using BelezanaWeb.Services.Shared;
using BelezanaWeb.SystemObjects.Exceptions;
using System.Net;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Services
{
    public class ProductService : GenericEntityService<Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public override async Task CreateAsync(Product entity, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetBySkuAsync(entity.Sku, cancellationToken);

            if (product == null || product.Deleted)
            {
                await base.CreateAsync(entity, cancellationToken);
            }
            else
            {
                throw new BelezanaWebApplicationException($"Produto com SKU {entity.Sku} já existe!", HttpStatusCode.BadRequest);
            }
        }

        public async Task<Product> GetBySkuAsync(int sku, CancellationToken cancellationToken = default)
        {
            return await _productRepository.GetBySkuAsync(sku, cancellationToken);
        }

        public async Task UpdateBySkuAsync(int sku, Product modifiedEntity, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetBySkuAsync(sku, cancellationToken);

            if (product == null)
            {
                throw new BelezanaWebApplicationException($"Produto com SKU {sku} não foi encontrado!", HttpStatusCode.NotFound);
            }

            modifiedEntity.Id = product.Id;

            await _productRepository.Update(modifiedEntity, cancellationToken);
        }

        public async Task DeleteBySkuAsync(int sku, CancellationToken cancellationToken = default)
        {
            var product = await _productRepository.GetBySkuAsync(sku, cancellationToken);

            // if it does not exist or is flagged as deleted
            if (product == null || product.Deleted)
            {
                throw new BelezanaWebApplicationException($"Produto com SKU {sku} não foi encontrado!", HttpStatusCode.NotFound);
            }

            // flag product as deleted
            product.Deleted = true;

            await _productRepository.Update(product, cancellationToken);
        }
    }
}

