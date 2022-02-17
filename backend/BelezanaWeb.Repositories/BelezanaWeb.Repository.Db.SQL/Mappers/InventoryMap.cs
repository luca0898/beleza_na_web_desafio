using BelezanaWeb.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezanaWeb.Db.SQL.Mappers
{
    public class InventoryMap : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder
                .HasKey(prop => prop.Id);

            builder
                .Property(prop => prop.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(prop => prop.Quantity)
                .IsRequired();

            builder
                .HasMany(a => a.Warehouses)
                .WithOne(b => b.Inventory);
        }
    }
}
