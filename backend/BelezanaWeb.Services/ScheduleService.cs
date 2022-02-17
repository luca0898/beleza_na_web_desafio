using BelezanaWeb.Product.Contracts.Repositories;
using BelezanaWeb.Product.Contracts.Services;
using BelezanaWeb.Product.Entities;
using BelezanaWeb.Services.Shared;
using BelezanaWeb.SystemObjects;
using BelezanaWeb.SystemObjects.Interfaces;

namespace BelezanaWeb.Service
{
    public class ScheduleService : GenericEntityService<Schedule>, IScheduleService
    {
        public ScheduleService(
            IScheduleRepository scheduleRepository,
            IUnitOfWorkFactory<UnitOfWork> uow) : base(scheduleRepository, uow)
        {
        }
    }
}
