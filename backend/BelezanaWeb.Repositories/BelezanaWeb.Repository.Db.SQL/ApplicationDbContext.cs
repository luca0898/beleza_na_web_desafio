using BelezanaWeb.Db.SQL.Mappers;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BelezanaWeb.Db.SQL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext Context => this;
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Claim>();
            modelBuilder.HasDefaultSchema("BelezanaWebDb");

            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new InventoryMap());
            modelBuilder.ApplyConfiguration(new ProductMap());
            modelBuilder.ApplyConfiguration(new ScheduleMap());
            modelBuilder.ApplyConfiguration(new WarehouseMap());
        }
    }
}
