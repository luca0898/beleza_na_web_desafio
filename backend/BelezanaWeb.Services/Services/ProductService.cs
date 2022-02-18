using BelezanaWeb.Product.Contracts.Repositories;
using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Services.Shared;
using BelezanaWeb.SystemObjects;
using BelezanaWeb.SystemObjects.Interfaces;

namespace BelezanaWeb.Services
{
    public class ProductService : GenericEntityService<Product.Entities.Product>, IProductService
    {
        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
        }
    }
}
