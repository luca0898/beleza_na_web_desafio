using BelezanaWeb.Product.Contracts.Repositories;
using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Services.Shared;
using System;
using BelezanaWeb.SystemObjects.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Services
{
    public class ProductService : GenericEntityService<Product.Entities.Product>, IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Product.Entities.Product> GetBySkuAsync(int sku, CancellationToken cancellationToken = default)
        {
            return await _productRepository.GetBySkuAsync(sku, cancellationToken);
        }
    }
}
