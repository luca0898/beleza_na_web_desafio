using BelezanaWeb.Db.SQL.Repositories.Shared;
using BelezanaWeb.Product.Contracts.Repositories;
using BelezanaWeb.Product.Entities;
using Microsoft.EntityFrameworkCore;

namespace BelezanaWeb.Db.SQL.Repositories
{
    public class ScheduleRepository : GenericRelationalRepository<Schedule>, IScheduleRepository
    {

        public ScheduleRepository(DbContext dbContext) : base(dbContext)
        {

        }
    }
}
