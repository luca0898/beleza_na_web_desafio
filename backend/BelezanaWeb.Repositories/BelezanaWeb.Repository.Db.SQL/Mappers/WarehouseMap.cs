using BelezanaWeb.Product.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BelezanaWeb.Db.SQL.Mappers
{
    public class WarehouseMap : IEntityTypeConfiguration<Warehouse>
    {
        public void Configure(EntityTypeBuilder<Warehouse> builder)
        {
            builder
                .HasKey(prop => prop.Id);

            builder
                .Property(prop => prop.Deleted)
                .HasDefaultValue(false)
                .IsRequired();

            builder
                .Property(prop => prop.Locality)
                .IsRequired();

            builder
                .Property(prop => prop.Quantity)
                .IsRequired();

            builder
                .Property(prop => prop.Type)
                .IsRequired();
        }
    }
}
