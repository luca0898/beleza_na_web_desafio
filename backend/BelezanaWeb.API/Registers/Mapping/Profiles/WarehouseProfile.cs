using AutoMapper;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Product.ViewModel;

namespace BelezanaWeb.Registers.Mapping
{
    public class WarehouseProfile : Profile
    {
        public WarehouseProfile()
        {
            CreateMap<Warehouse, WarehouseViewModel>().ReverseMap();
        }
    }
}
