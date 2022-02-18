using AutoMapper;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Product.InputModel;
using BelezanaWeb.Product.ViewModels;

namespace BelezanaWeb.Registers.Mapping
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseViewModel>().ReverseMap();
            CreateMap<Warehouse, WarehouseInputModel>().ReverseMap();
        }
    }
}
