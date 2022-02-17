using AutoMapper;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Product.ViewModel;

namespace BelezanaWeb.Registers.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product.Entities.Product, ProductViewModel>().ReverseMap();
        }
    }
}
