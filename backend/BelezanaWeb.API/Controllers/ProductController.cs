using AutoMapper;
using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Product.InputModel;
using BelezanaWeb.Product.ViewModels;
using BelezanaWeb.SystemObjects.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace BelezanaWeb.Controllers
{
    [Route("v1/product")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet, Route("{sku}")]
        [SwaggerOperation(OperationId = "{entity}GetBySku")]
        public async Task<IActionResult> GetBySkuAsync(int sku)
        {
            Product.Entities.Product entity = await _productService.GetBySkuAsync(sku);

            ProductViewModel entityView = _mapper.Map<ProductViewModel>(entity);

            return Ok(new SuccessResponseViewModel<ProductViewModel>(entityView));
        }

        [HttpPost, Route("")]
        public async Task<IActionResult> CreateAsync([FromBody] ProductInputModel model, CancellationToken cancellationToken)
        {
            await _productService.CreateAsync(_mapper.Map<Product.Entities.Product>(model), cancellationToken);

            return NoContent();
        }

        [HttpPut, Route("{sku}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int sku, [FromBody] ProductInputModel model, CancellationToken cancellationToken)
        {
            var modifiedEntity = _mapper.Map<Product.Entities.Product>(model);

            await _productService.UpdateBySkuAsync(sku, modifiedEntity, cancellationToken);

            return NoContent();
        }

        [HttpDelete, Route("{sku}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int sku, CancellationToken cancellationToken)
        {
            await _productService.DeleteBySkuAsync(sku, cancellationToken);

            return NoContent();
        }
    }
}
