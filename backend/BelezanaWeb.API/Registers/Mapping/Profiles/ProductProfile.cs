using AutoMapper;
using BelezanaWeb.Product.InputModel;
using BelezanaWeb.Product.ViewModels;

namespace BelezanaWeb.Registers.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product.Entities.Product, ProductViewModel>().ReverseMap();
            CreateMap<Product.Entities.Product, ProductInputModel>().ReverseMap();
        }
    }
}
