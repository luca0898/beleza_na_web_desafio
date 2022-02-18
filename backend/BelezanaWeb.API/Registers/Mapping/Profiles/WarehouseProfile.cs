using AutoMapper;
using BelezanaWeb.Domain.Entities;
using BelezanaWeb.Domain.InputModel;
using BelezanaWeb.Domain.ViewModels;

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
