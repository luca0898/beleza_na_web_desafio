using AutoMapper;
using BelezanaWeb.Domain.Entities;
using BelezanaWeb.Domain.InputModel;
using BelezanaWeb.Domain.ViewModels;

namespace BelezanaWeb.Registers.Mapping
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
            CreateMap<Product, ProductInputModel>().ReverseMap();
        }
    }
}
