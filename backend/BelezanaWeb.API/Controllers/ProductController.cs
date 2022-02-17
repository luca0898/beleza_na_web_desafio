using AutoMapper;
using BelezanaWeb.Controllers.Shared;
using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Product.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BelezanaWeb.Controllers
{
    [Route("v1/product")]
    public class ProductController : BaseController<Product.Entities.Product, ProductViewModel, ProductViewModel>
    {
        public ProductController(
            IProductService productService,
            IMapper mapper)
            : base(productService, mapper)
        {
        }
    }
}
