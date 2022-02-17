using AutoMapper;
using BelezanaWeb.Controllers.Shared;
using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Product.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace BelezanaWeb.Controllers
{
    [Route("v1/schedule")]
    public class ScheduleController : BaseController<Schedule, ScheduleViewModel, ScheduleViewModel>
    {
        public ScheduleController(
            IScheduleService scheduleService,
            IMapper mapper)
            : base(scheduleService, mapper)
        {
        }
    }
}
