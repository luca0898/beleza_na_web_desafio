using AutoMapper;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Product.ViewModel;

namespace BelezanaWeb.Registers.Mapping
{
    public class InventoryProfile : Profile
    {
        public InventoryProfile()
        {
            CreateMap<Inventory, InventoryViewModel>().ReverseMap();
        }
    }
}
