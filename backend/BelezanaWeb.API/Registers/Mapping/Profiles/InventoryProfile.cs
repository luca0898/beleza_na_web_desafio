using AutoMapper;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Product.InputModel;
using BelezanaWeb.Product.ViewModels;

namespace BelezanaWeb.Registers.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryViewModel>().ReverseMap();
            CreateMap<Inventory, InventoryInputModel>().ReverseMap();
        }
    }
}
