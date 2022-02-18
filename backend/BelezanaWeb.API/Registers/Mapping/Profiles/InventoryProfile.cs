using AutoMapper;
using BelezanaWeb.Domain.Entities;
using BelezanaWeb.Domain.InputModel;
using BelezanaWeb.Domain.ViewModels;

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
