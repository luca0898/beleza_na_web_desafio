using BelezanaWeb.Domain.Contracts.Repositories;
using BelezanaWeb.Domain.Contracts.Services;
using BelezanaWeb.Domain.Entities;
using BelezanaWeb.Services;
using BelezanaWeb.SystemObjects.Exceptions;
using FakeItEasy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace BelezanaWeb.Tests.Unit.Services
{
    public class ProductServiceTests
    {
        private IProductService _service;
        private IProductRepository _repository;

        public ProductServiceTests()
        {
            _repository = A.Fake<IProductRepository>();

            _service = new ProductService(_repository);
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateProduct_WhenNoProductWithSameSkuExistsAsync()
        {
            Product product = A.Fake<Product>();
            CancellationToken cancellationToken = default;

            Product? expectedProduct = product;
            expectedProduct.Deleted = true;

            A.CallTo(() => _repository.GetBySkuAsync(product.Sku, cancellationToken))
                .Returns(expectedProduct);

            await _service.CreateAsync(product, cancellationToken);

            A.CallTo(() => _repository.CreateAsync(product, cancellationToken)).MustHaveHappened();
        }

        [Fact]
        public async Task CreateAsync_ShouldCreateProduct_WhenNoProductWithSameSkuExistsOrIsDeletedAsync()
        {
            Product product = A.Fake<Product>();
            CancellationToken cancellationToken = default;

            Product? expectedProduct = null;

            A.CallTo(() => _repository.GetBySkuAsync(product.Sku, cancellationToken))
                .Returns(expectedProduct);

            await _service.CreateAsync(product, cancellationToken);

            A.CallTo(() => _repository.CreateAsync(product, cancellationToken)).MustHaveHappened();
        }

        [Fact]
        public async Task CreateAsync_ShouldNotCreateProduct_WhenProductWithSameSkuExistsAsync()
        {
            Product product = A.Fake<Product>();
            product.Sku = 123;
            CancellationToken cancellationToken = default;

            Product? expectedProduct = A.Fake<Product>();
            expectedProduct.Sku = product.Sku;

            A.CallTo(() => _repository.GetBySkuAsync(product.Sku, cancellationToken))
                .Returns(expectedProduct);

            try
            {
                await _service.CreateAsync(product, cancellationToken);
            }
            catch (BelezanaWebApplicationException ex)
            {
                Assert.Equal("Produto com SKU 123 já existe!", ex.Message);
            }
        }

        [Fact]
        public async Task CreateAsync_ShouldNotCreateProduct_WhenProductWithSameSkuExistsAndIsNotDeletedAsync()
        {
            Product product = A.Fake<Product>();
            product.Sku = 123;
            product.Deleted = false;
            CancellationToken cancellationToken = default;

            Product? expectedProduct = A.Fake<Product>();
            expectedProduct.Sku = product.Sku;
            expectedProduct.Deleted = product.Deleted;

            A.CallTo(() => _repository.GetBySkuAsync(product.Sku, cancellationToken))
                .Returns(expectedProduct);

            try
            {
                await _service.CreateAsync(product, cancellationToken);
            }
            catch (BelezanaWebApplicationException ex)
            {
                Assert.Equal("Produto com SKU 123 já existe!", ex.Message);
            }
        }

        [Fact]
        public async Task GetBySkuAsync_ShouldQueryInTheRepositoryWithSameSkuAsService_WhenServiceProvideTheSkuAsync()
        {
            int productSku = 123;
            CancellationToken cancellationToken = default;

            await _service.GetBySkuAsync(productSku, cancellationToken);

            A.CallTo(() => _repository.GetBySkuAsync(productSku, cancellationToken)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task UpdateBySkuAsync_ShouldUpdateProduct_WhenProductIsFoundAsync()
        {
            Product product = A.Fake<Product>();
            product.Sku = 123;
            product.Deleted = false;
            CancellationToken cancellationToken = default;

            Product? expectedProduct = A.Fake<Product>();
            expectedProduct.Sku = product.Sku;
            expectedProduct.Deleted = product.Deleted;

            A.CallTo(() => _repository.GetBySkuAsync(product.Sku, cancellationToken))
                .Returns(expectedProduct);

            await _service.UpdateBySkuAsync(product.Sku, product, cancellationToken);

            A.CallTo(() => _repository.Update(product, cancellationToken))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task UpdateBySkuAsync_ShouldNotUpdateProduct_WhenProductIsNotFoundAsync()
        {
            Product product = A.Fake<Product>();
            product.Sku = 123;
            product.Deleted = false;
            CancellationToken cancellationToken = default;

            Product? expectedProduct = null;

            A.CallTo(() => _repository.GetBySkuAsync(product.Sku, cancellationToken))
                .Returns(expectedProduct);

            try
            {
                await _service.CreateAsync(product, cancellationToken);
            }
            catch (BelezanaWebApplicationException ex)
            {
                Assert.Equal("Produto com SKU 123 não foi encontrado!", ex.Message);
            }
        }

        [Fact]
        public async Task DeleteBySkuAsync_ShouldFlagProductAsDeleted_WhenProductIsFoundAsync()
        {
            CancellationToken cancellationToken = default;

            Product? expectedProduct = A.Fake<Product>();
            expectedProduct.Sku = 123;
            expectedProduct.Deleted = false;

            A.CallTo(() => _repository.GetBySkuAsync(expectedProduct.Sku, cancellationToken))
                .Returns(expectedProduct);

            await _service.DeleteBySkuAsync(expectedProduct.Sku, cancellationToken);

            A.CallTo(() => _repository.Update(expectedProduct, cancellationToken))
                .MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task DeleteBySkuAsync_ShouldNotFlagTheProductAsDeleted_WhenProductIsNotFoundAsync()
        {
            Product product = A.Fake<Product>();
            product.Sku = 123;
            product.Deleted = false;
            CancellationToken cancellationToken = default;

            Product? expectedProduct = null;

            A.CallTo(() => _repository.GetBySkuAsync(product.Sku, cancellationToken))
                .Returns(expectedProduct);

            try
            {
                await _service.DeleteBySkuAsync(product.Sku, cancellationToken);
            }
            catch (BelezanaWebApplicationException ex)
            {
                Assert.Equal("Produto com SKU 123 não foi encontrado!", ex.Message);
            }
        }
    }
}
