using AutoMapper;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Product.ViewModel;

namespace BelezanaWeb.Registers.Mapping
{
    public class ScheduleProfile : Profile
    {
        public ScheduleProfile()
        {
            CreateMap<Schedule, ScheduleViewModel>().ReverseMap();
        }
    }
}
